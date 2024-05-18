using GadgetGrove.Domain.Enums.OrderStatuses;
using GadgetGrove.Domain.Enums.PaymentStatuses;

namespace GadgetGrove.Service.DTOs.Orders;

public class OrderForUpdateDto
{
    public long AddressId { get; set; }
    public long PaymentId { get; set; }
    public long DeviceId { get; set; }
    public long ApplianceId { get; set; }
    public long AccessoryId { get; set; }
    public long VideoAudioBoxId { get; set; }
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}
