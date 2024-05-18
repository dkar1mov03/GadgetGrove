using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Locations;

namespace GadgetGrove.Service.Interfaces.Locations;

public interface ILocationService
{
    Task<bool> RemoveAsync(long id);
    Task<LocationForResultDto> RetrieveByIdAsync(long id);
    Task<LocationForResultDto> AddAsync(LocationForCreationDto dto);
    Task<LocationForResultDto> ModifyAsync(long id, LocationForCreationDto dto);
    Task<IEnumerable<LocationForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
