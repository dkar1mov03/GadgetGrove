using GadgetGrove.Domain.Enums.PaymentStatuses;

namespace GadgetGrove.Service.DTOs.Payments;

public class PaymentForUpdateDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public PaymentStatus Status { get; set; }
    public long UserId { get; set; }
    public long FileId { get; set; }
}
