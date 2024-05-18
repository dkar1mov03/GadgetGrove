using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Enums.Discounts;
using GadgetGrove.Service.DTOs.Discounts;

namespace GadgetGrove.Service.Interfaces.Discounts;

public interface IDiscountService
{
    Task<DiscountForResultDto> RetrieveByIdAsnyc(long id);
    Task<DiscountForResultDto> AddAsync(DiscountForCreationDto dto);
    Task<DiscountForResultDto> ModifyAsync(long id, DiscountForUpdateDto dto);
    Task<IEnumerable<DiscountForResultDto>> RetrieveAllAsync(PaginationParams @params, DiscountState? state = null);
}
