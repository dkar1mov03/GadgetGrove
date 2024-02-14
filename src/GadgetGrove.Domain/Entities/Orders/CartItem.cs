using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Products;
using GadgetGrove.Domain.Entities.WhereHouses;

namespace GadgetGrove.Domain.Entities.Orders;

public class CartItem : Auditable
{
    public long CartId { get; set; }
    public Cart Cart { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }

    public long ProductInventoryAssignmentId { get; set; }
    public ProductMallInventoryAssignment productInventoryAssignment { get; set; }

    public int Amount { get; set; }
}
