using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Accessories;
using GadgetGrove.Domain.Entities.Addresses;
using GadgetGrove.Domain.Entities.Appliances;
using GadgetGrove.Domain.Entities.Devices;
using GadgetGrove.Domain.Entities.Orders.Feedbacks;
using GadgetGrove.Domain.Entities.VideoAudioBoxs;
using GadgetGrove.Domain.Enums.OrderStatuses;
using GadgetGrove.Domain.Enums.PaymentStatuses;

namespace GadgetGrove.Domain.Entities.Orders;

public class Order : Auditable
{
    public long AddressId { get; set; }
    public Address Address { get; set; }
    public long PaymentId { get; set; }
    public Payment Payment { get; set; }
    public long DeviceId { get; set; }
    public Device Device { get; set; }
    public long ApplianceId { get; set; }
    public Appliance Appliance { get; set; }
    public long AccessoryId { get; set; }
    public Accessory Accessory { get; set; }
    public long VideoAudioBoxId { get; set; }
    public VideoAudiBox VideoAudiBox { get; set; }
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
}
