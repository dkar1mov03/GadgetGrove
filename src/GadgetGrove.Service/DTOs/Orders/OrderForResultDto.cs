using GadgetGrove.Domain.Entities.Orders.Feedbacks;
using GadgetGrove.Domain.Enums.OrderStatuses;
using GadgetGrove.Domain.Enums.PaymentStatuses;
using GadgetGrove.Service.DTOs.Accessories;
using GadgetGrove.Service.DTOs.Addresses;
using GadgetGrove.Service.DTOs.Appliances;
using GadgetGrove.Service.DTOs.AudioVideoBoxes;
using GadgetGrove.Service.DTOs.Devices;
using GadgetGrove.Service.DTOs.Payments;

namespace GadgetGrove.Service.DTOs.Orders;

public class OrderForResultDto
{
    public long AddressId { get; set; }
    public AddressForResultDto Address { get; set; }
    public long PaymentId { get; set; }
    public PaymentForResultDto Payment { get; set; }
    public long DeviceId { get; set; }
    public DeviceForResultDto Device { get; set; }
    public long ApplianceId { get; set; }
    public ApplianceForResultDto Appliance { get; set; }
    public long AccessoryId { get; set; }
    public AccessoryForResultDto Accessory { get; set; }
    public long VideoAudioBoxId { get; set; }
    public AudioVideoBoxForResultDto AudioVideoBox { get; set; }    
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
}
