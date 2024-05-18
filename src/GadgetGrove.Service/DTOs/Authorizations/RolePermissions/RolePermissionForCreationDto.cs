using GadgetGrove.Service.DTOs.Authorizations.Permissions;
using System.ComponentModel.DataAnnotations;

namespace GadgetGrove.Service.DTOs.Authorizations.RolePermissions;

public class RolePermissionForCreationDto
{
    public long RoleId { get; set; }
    public long PermissonId { get; set; }
}
