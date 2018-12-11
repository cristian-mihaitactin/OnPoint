using Abp.Authorization;
using eMMA.Authorization.Roles;
using eMMA.Authorization.Users;

namespace eMMA.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
