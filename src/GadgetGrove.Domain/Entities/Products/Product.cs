using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Accessories;
using GadgetGrove.Domain.Entities.Appliances;
using GadgetGrove.Domain.Entities.Devices;
using GadgetGrove.Domain.Entities.Orders;

namespace GadgetGrove.Domain.Entities.Products;

public class Product : Auditable
{
    public long DeviceId { get; set; }
    public Device Device { get; set; }
    public long AccessoryId { get; set; }
    public Accessory Accessory { get; set; }
    public long ApplianceId { get; set; }
    public Appliance Appliance { get; set; }
    public ICollection<Discount> Discounts { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
