using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.DeviceAssets;
using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.Interfaces.DeviceAssets;

public interface IDeviceAssetService
{
    public Task<bool> RemoveAsync(long deviceid, long id);
    public Task<DeviceAssetForResultDto> AddAsync(long deviceid, IFormFile file);
    public Task<DeviceAssetForResultDto> RetrieveByIdAsync(long deviceid, long id);
    public Task<IEnumerable<DeviceAssetForResultDto>> RetrieveAllAsync(long deviceid, PaginationParams @params);
}
