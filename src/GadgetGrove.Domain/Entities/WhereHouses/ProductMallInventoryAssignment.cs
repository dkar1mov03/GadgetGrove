using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Orders;

namespace GadgetGrove.Domain.Entities.WhereHouses;

public class ProductMallInventoryAssignment : Auditable
{
    public int Amount { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long LocationId { get; set; }
    public Location Location { get; set; }
}
