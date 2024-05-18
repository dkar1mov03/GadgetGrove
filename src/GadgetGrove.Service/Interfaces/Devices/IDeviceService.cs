using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Devices;

namespace GadgetGrove.Service.Interfaces.Devices;

public interface IDeviceService
{
    Task<bool> RemoveAsync(long id);
    Task<DeviceForResultDto> RetrieveByIdAsync(long id);
    Task<DeviceForResultDto> AddAsync(DeviceForCreationDto dto);
    Task<DeviceForResultDto> ModifyAsync(long id, AudioVideoForUpdateDto dto);
    Task<IEnumerable<DeviceForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
