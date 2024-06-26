﻿using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Enums.Discounts;

namespace GadgetGrove.Domain.Entities.Orders;

public class Discount : Auditable
{
    public long PaymentId { get; set; }
    public Payment Payment { get; set; }
    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    public DateTime FinishedAt { get; set; }
    public decimal PercentageToCheapen { get; set; }
    public DiscountState State { get; set; } = DiscountState.Active;
}