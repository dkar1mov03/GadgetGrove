using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Enums.OrderStatuses;

namespace GadgetGrove.Service.DTOs.OrderActions;

public class OrderActionForUpdateDto
{
    public long OrderId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime ApproximateFinishTime { get; set; }
}
