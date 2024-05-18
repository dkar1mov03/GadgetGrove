using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Authorizations;
using GadgetGrove.Service.DTOs.Authorizations.Roles;

namespace GadgetGrove.Service.Interfaces.Authorizations;

public interface IRoleService
{
    Task<bool> RemoveAsync(long id);
    Task<Role> RetrieveByIdForAuthAsync(long id);
    Task<bool> ModifyAsync(RoleForUpdateDto dto);
    Task<RoleForResultDto> RetrieveByIdAsync(long id);
    Task<RoleForResultDto> AddAsync(RoleForCreationDto dto);
    Task<IEnumerable<RoleForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
