using System.Collections.Generic;
using eMMA.Roles.Dto;
using eMMA.Users.Dto;

namespace eMMA.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
