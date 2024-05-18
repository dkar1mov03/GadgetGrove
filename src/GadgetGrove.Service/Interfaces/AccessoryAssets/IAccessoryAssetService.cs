using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.AccessoryAssets;
using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.Interfaces.AccessoryAssets;

public interface IAccessoryAssetService
{
    Task<bool> RemoveAsync(long AccessoryId, long id);
    Task<AccessoryAssetForResultDto> AddAsync(long AccessoryId, IFormFile file);
    Task<AccessoryAssetForResultDto> RetrieveByIdASync(long AccessoryId, long id);
    Task<IEnumerable<AccessoryAssetForResultDto>> RetrieveAllAsync(long AccessoryId, PaginationParams @params);
}
