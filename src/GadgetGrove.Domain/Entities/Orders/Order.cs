using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Addresses;
using GadgetGrove.Domain.Entities.Orders.Feedbacks;
using GadgetGrove.Domain.Entities.Users;
using GadgetGrove.Domain.Enums.OrderStatuses;
using GadgetGrove.Domain.Enums.PaymentStatuses;

namespace GadgetGrove.Domain.Entities.Orders;

public class Order : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long AddressId { get; set; }
    public Address Address { get; set; }
    public long PaymentId { get; set; }
    public Payment Payment { get; set; }
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public ICollection<OrderAction> Actions { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
}
