using System.ComponentModel.DataAnnotations;

namespace GadgetGrove.Service.DTOs.Authorizations.Roles;

public class RoleForUpdateDto
{
    public long RoleId { get; set; }
    public string Name { get; set; }
}