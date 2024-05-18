using GadgetGrove.Service.DTOs.Authorizations.Permissions;
using GadgetGrove.Service.DTOs.Authorizations.Roles;

namespace GadgetGrove.Service.DTOs.Authorizations.RolePermissions;

public class RolePermissionForResultDto
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public RoleForResultDto Role { get; set; }
    public long PermissonId { get; set; }
    public PermissionForResultDto Permisson { get; set; }
}
