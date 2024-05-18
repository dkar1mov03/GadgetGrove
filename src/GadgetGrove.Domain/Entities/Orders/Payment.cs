using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Attechments;
using GadgetGrove.Domain.Entities.Users;
using GadgetGrove.Domain.Enums.PaymentStatuses;

namespace GadgetGrove.Domain.Entities.Orders;

public class Payment : Auditable
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public PaymentStatus Status { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long FileId { get; set; }
    public Attachment File { get; set; }
    public ICollection<Order> Orders { get; set; }
}
