using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Addresses;

namespace GadgetGrove.Service.Interfaces.Addresses;

public interface IAddressService
{
    Task<bool> RemoveAsync(long id);
    Task<AddressForResultDto> RetrieveByIdAsync(long id);
    Task<AddressForResultDto> AddAsync(AddressForCreationDto address);
    Task<AddressForResultDto> ModifyAsync(long id, AddressForCreationDto dto);
    Task<IEnumerable<AddressForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
