using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Entities.Users;
using GadgetGrove.Domain.Enums.PaymentStatuses;

namespace GadgetGrove.Service.DTOs.Payments;

public class PaymentForCreationDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public PaymentStatus Status { get; set; }
    public long UserId { get; set; }
    public long FileId { get; set; }
}
