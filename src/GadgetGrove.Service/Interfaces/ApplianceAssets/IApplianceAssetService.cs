using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.ApplianceAssets;
using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.Interfaces.ApplianceAssets;

public interface IApplianceAssetService
{
    public Task<bool> RemoveAsync(long ApplianceId, long id);
    public Task<ApplianceAssetForResultDto> AddAsync(long ApplianceId, IFormFile file);
    public Task<ApplianceAssetForResultDto> RetrieveByIdAsync(long ApplianceId, long id);
    public Task<IEnumerable<ApplianceAssetForResultDto>> RetrieveAllAsync(long ApplianceId, PaginationParams @params);
}
