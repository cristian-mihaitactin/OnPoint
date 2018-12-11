using System.Collections.Generic;
using eMMA.Roles.Dto;

namespace eMMA.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}