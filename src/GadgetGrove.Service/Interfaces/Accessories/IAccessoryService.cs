using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Accessories;

namespace GadgetGrove.Service.Interfaces.Accessories;

public interface IAccessoryService
{
    Task<bool> RemoveAsync(long id);
    Task<AccessoryForResultDto> RetrieveByIdAsync(long id);
    Task<AccessoryForResultDto> AddAsync(AccessoryForCreationDto dto);
    Task<AccessoryForResultDto> ModifyAsync(long id,AccessoryForUpdateDto dto);
    Task<IEnumerable<AccessoryForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
