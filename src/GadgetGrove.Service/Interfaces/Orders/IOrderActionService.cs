using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Enums.OrderStatuses;
using GadgetGrove.Service.DTOs.OrderActions;
using GadgetGrove.Service.DTOs.Orders;

namespace GadgetGrove.Service.Interfaces.Orders;

public interface IOrderActionService
{
    Task<bool> RemoveAsync(long id);
    Task<OrderActionForResultDto> RetrieveByIdAsync(long id);
    Task<OrderActionForResultDto> AddAsync(OrderActionForCreationDto dto);
    Task<OrderActionForResultDto> ModifyAsync(long id, OrderActionForUpdateDto dto);
    Task<IEnumerable<OrderActionForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
