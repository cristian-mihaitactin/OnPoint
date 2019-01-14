using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using eMMA.Authorization;
using eMMA.Authorization.Roles;
using eMMA.Authorization.Users;

namespace eMMA.EntityFrameworkCore.Seed.Tenants
{
    public class TenantRoleAndUserBuilder
    {
        private readonly eMMADbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(eMMADbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            // Admin role

            var adminRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            // Student and Professor roles
            var studTenantId = _tenantId + 1;
            var profTenantId = _tenantId + 2;

            var studentRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == studTenantId && r.Name == StaticRoleNames.Tenants.Student);
            if (studentRole == null)
            {
                studentRole = _context.Roles.Add(new Role(studTenantId, StaticRoleNames.Tenants.Student, StaticRoleNames.Tenants.Student) { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            var professorRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == profTenantId && r.Name == StaticRoleNames.Tenants.Professor);
            if (professorRole == null)
            {
                professorRole = _context.Roles.Add(new Role(profTenantId, StaticRoleNames.Tenants.Professor, StaticRoleNames.Tenants.Professor) { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            // Grant all permissions to admin role

            var grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                .OfType<RolePermissionSetting>()
                .Where(p => p.TenantId == _tenantId && p.RoleId == adminRole.Id)
                .Select(p => p.Name)
                .ToList();

            var permissions = PermissionFinder
                .GetAllPermissions(new eMMAAuthorizationProvider())
                .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                            !grantedPermissions.Contains(p.Name))
                .ToList();

            if (permissions.Any())
            {
                _context.Permissions.AddRange(
                    permissions.Select(permission => new RolePermissionSetting
                    {
                        TenantId = _tenantId,
                        Name = permission.Name,
                        IsGranted = true,
                        RoleId = adminRole.Id
                    })
                );
                _context.SaveChanges();
            }

            // Admin user

            var adminUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == AbpUserBase.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com");
                adminUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(adminUser, "123qwe");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }

            /////////////////////////////////////////
            ///             // Student and prof user

            var studUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == studTenantId && u.UserName == "stud1");
            if (studUser == null)
            {
                studUser = User.CreateTenantAdminUser(studTenantId, "stud1@defaulttenant.com");
                studUser.UserName = "stud1";
                studUser.Name = "First";
                studUser.Surname = "Secondsur";

                studUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(studUser, "123qwe");
                studUser.IsEmailConfirmed = true;
                studUser.IsActive = true;

                _context.Users.Add(studUser);
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(studTenantId, studUser.Id, studentRole.Id));
                _context.SaveChanges();
            }

            var profUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == profTenantId && u.UserName == "prof1");
            if (profUser == null)
            {
                profUser = User.CreateTenantAdminUser(profTenantId, "prof1@defaulttenant.com");
                profUser.UserName = "prof1";
                profUser.Name = "Firstprof";
                profUser.Surname = "Secondprof";

                profUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(profUser, "123qwe");
                profUser.IsEmailConfirmed = true;
                profUser.IsActive = true;

                _context.Users.Add(profUser);
                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(profTenantId, profUser.Id, professorRole.Id));
                _context.SaveChanges();
            }
            /// /////////////////////////////////////
        }
    }
}
