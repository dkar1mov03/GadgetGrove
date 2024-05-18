using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Enums.OrderStatuses;

namespace GadgetGrove.Service.DTOs.OrderActions;

public class OrderActionForResultDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime ApproximateFinishTime { get; set; }
}
