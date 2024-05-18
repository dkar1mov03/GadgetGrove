using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Enums.Discounts;
using GadgetGrove.Service.DTOs.Payments;

namespace GadgetGrove.Service.DTOs.Discounts;

public class DiscountForResultDto
{
    public long Id { get; set; }    
    public long PaymentId { get; set; }
    public PaymentForResultDto Payment { get; set; }
    public DateTime StartedAt { get; set; } 
    public DateTime FinishedAt { get; set; }
    public decimal PercentageToCheapen { get; set; }
    public DiscountState State { get; set; }
}
