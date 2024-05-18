using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Appliances;

namespace GadgetGrove.Service.Interfaces.Appliances;

public interface IApplianceService
{
    Task<bool> RemoveAsync(long id);
    Task<ApplianceForResultDto> RetriaveByIdAsync(long id);
    Task<ApplianceForResultDto> AddAync(ApplianceForCreationDto dto);
    Task<ApplianceForResultDto> ModifyAsync(long id, ApplianceForUpdateDto dto);
    Task<IEnumerable<ApplianceForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
