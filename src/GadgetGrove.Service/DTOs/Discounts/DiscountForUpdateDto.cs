namespace GadgetGrove.Service.DTOs.Discounts;

public class DiscountForUpdateDto
{
    public long PaymentId { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime FinishedAt { get; set; }
    public decimal PercentageToCheapen { get; set; }
}
