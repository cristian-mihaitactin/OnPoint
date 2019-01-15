using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using eMMA.Authorization;
using eMMA.Authorization.Roles;
using eMMA.Authorization.Users;
using eMMA.Entities;
using eMMA.Roles.Dto;
using eMMA.Users.Dto;
using User = eMMA.Authorization.Users.User;

namespace eMMA.Users
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRepository<Student, Guid> _studentsRepository;
        private readonly IRepository<Professor, Guid> _profRepository;

        public UserAppService(
            IRepository<User, long> repository,
            UserManager userManager,
            RoleManager roleManager,
            IRepository<Role> roleRepository,
            IPasswordHasher<User> passwordHasher,
            IRepository<Student, Guid> studentsRepository,
            IRepository<Professor, Guid> profRepository)
            : base(repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
            _studentsRepository = studentsRepository;
            _profRepository = profRepository;
        }

        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

            try
            {
                CheckErrors(await _userManager.CreateAsync(user, input.Password));
            }
            catch (Exception ex)
            {
                throw;
            }

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            CurrentUnitOfWork.SaveChanges();

            await CreateUniUser(input, user.Id);

            return MapToEntityDto(user);
        }

        public override async Task<UserDto> Update(UserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
                await CreateUniUser(input, user.Id);
            }

            return await Get(input);
        }

        public async Task<Entities.User> CreateUniUser(UserDto input, long userId)
        {
            //also create students or profs
            if ((input.RoleNames ?? throw new InvalidOperationException()).Contains("Student",StringComparer.InvariantCultureIgnoreCase))
            {
                return await _studentsRepository.InsertAsync(new Student()
                {
                    UserId = userId,
                    FirstName = input.Name,
                    Username = input.UserName,
                    Email = input.EmailAddress,
                    LastName = input.Surname,
                    NrMatricol = Guid.NewGuid().ToString().Trim('-').Substring(0, 20),
                });

            }
            if ((input.RoleNames ?? throw new InvalidOperationException()).Contains("Professor", StringComparer.InvariantCultureIgnoreCase))
            {
                return await _profRepository.InsertAsync(new Professor()
                {
                    UserId = userId,
                    FirstName = input.Name,
                    Username = input.UserName,
                    Email = input.EmailAddress,
                    LastName = input.Surname
                });
            }

            return null;
        }

        public async Task<Entities.User> CreateUniUser(CreateUserDto input, long userId)
        {
            //also create students or profs
            if ((input.RoleNames ?? throw new InvalidOperationException()).Contains("Student", StringComparer.InvariantCultureIgnoreCase))
            {
                return await _studentsRepository.InsertAsync(new Student()
                {
                    UserId = userId,
                    FirstName = input.Name,
                    Username = input.UserName,
                    Email = input.EmailAddress,
                    LastName = input.Surname,
                    NrMatricol = Guid.NewGuid().ToString().Trim('-').Substring(0, 20),
                });

            }
            if ((input.RoleNames ?? throw new InvalidOperationException()).Contains("Professor", StringComparer.InvariantCultureIgnoreCase))
            {
                return await _profRepository.InsertAsync(new Professor()
                {
                    UserId = userId,
                    FirstName = input.Name,
                    Username = input.UserName,
                    Email = input.EmailAddress,
                    LastName = input.Surname
                });
            }

            return null;
        }
        public override async Task Delete(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        public async Task ChangeLanguage(ChangeUserLanguageDto input)
        {
            await SettingManager.ChangeSettingForUserAsync(
                AbpSession.ToUserIdentifier(),
                LocalizationSettingNames.DefaultLanguage,
                input.LanguageName
            );
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            user.SetNormalizedNames();
            return user;
        }

        protected override void MapToEntity(UserDto input, User user)
        {
            ObjectMapper.Map(input, user);
            user.SetNormalizedNames();
        }

        protected override UserDto MapToEntityDto(User user)
        {
            var roles = _roleManager.Roles.Where(r => user.Roles.Any(ur => ur.RoleId == r.Id)).Select(r => r.NormalizedName);
            var userDto = base.MapToEntityDto(user);
            userDto.RoleNames = roles.ToArray();
            return userDto;
        }

        protected override IQueryable<User> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Roles);
        }

        protected override async Task<User> GetEntityByIdAsync(long id)
        {
            var user = await Repository.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }

            return user;
        }

        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.UserName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
