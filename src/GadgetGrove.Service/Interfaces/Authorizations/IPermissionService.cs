using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Authorizations.Permissions;

namespace GadgetGrove.Service.Interfaces.Authorizations;

public interface IPermissionService
{
    Task<bool> RemoveAsync(long id);
    Task<PermissionForResultDto> RetrieveByIdAsync(long id);
    Task<PermissionForResultDto> ModifyAsync(PermissionForUpdateDto dto);
    Task<PermissionForResultDto> CreateAsync(PermissionForCreationDto dto);
    Task<List<PermissionForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
