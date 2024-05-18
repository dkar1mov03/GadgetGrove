using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Enums.Discounts;

namespace GadgetGrove.Service.DTOs.Discounts;

public class DiscountForCreationDto
{
    public long PaymentId { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime FinishedAt { get; set; }
    public decimal PercentageToCheapen { get; set; }
}
