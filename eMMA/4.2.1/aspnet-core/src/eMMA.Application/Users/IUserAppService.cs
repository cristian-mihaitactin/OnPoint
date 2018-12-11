using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eMMA.Roles.Dto;
using eMMA.Users.Dto;

namespace eMMA.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
