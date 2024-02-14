using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Enums.OrderStatuses;

namespace GadgetGrove.Domain.Entities.Orders;

public class OrderAction : Auditable
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime ApproximateFinishTime { get; set; }
}
