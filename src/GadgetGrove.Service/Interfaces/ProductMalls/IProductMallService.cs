using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.ProductMalls;

namespace GadgetGrove.Service.Interfaces.ProductMalls;

public interface IProductMallService
{
    Task<bool> RemoveAsync(long id);
    Task<ProductMallForResultDto> RetrieveByIdAsync(long id);   
    Task<ProductMallForResultDto> AddAsync(ProductMallForCreationDto dto);
    Task<ProductMallForResultDto> ModifyAsync(long id,ProductMallForUpdateDto dto);
    Task<IEnumerable<ProductMallForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
