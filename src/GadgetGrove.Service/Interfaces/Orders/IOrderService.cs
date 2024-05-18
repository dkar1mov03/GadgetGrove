using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Orders;

namespace GadgetGrove.Service.Interfaces.Orders;

public interface IOrderService
{
    Task<bool>RemoveAsync(long id);
    Task<OrderForResultDto> RetrieveByIdAsync(long id);
    Task<OrderForResultDto> AddAsync(OrderForCreationDto dto);
    Task<OrderForResultDto> ModifyAsync(long id, OrderForUpdateDto dto);
    Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
