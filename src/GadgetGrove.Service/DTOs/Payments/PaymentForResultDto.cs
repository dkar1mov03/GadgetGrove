using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Enums.PaymentStatuses;
using GadgetGrove.Service.DTOs.Attachments;
using GadgetGrove.Service.DTOs.Users;

namespace GadgetGrove.Service.DTOs.Payments;

public class PaymentForResultDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public PaymentStatus Status { get; set; }
    public long UserId { get; set; }
    public UserForResultDto User { get; set; }
    public long FileId { get; set; }
    public AttachmentForResultDto File { get; set; }
    public ICollection<Order> Orders { get; set; }
}
