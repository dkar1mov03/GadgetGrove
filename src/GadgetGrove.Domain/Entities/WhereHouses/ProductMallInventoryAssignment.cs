using GadgetGrove.Domain.Entities.Products;

namespace GadgetGrove.Domain.Entities.WhereHouses;

public class ProductMallInventoryAssignment
{
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public int Amount { get; set; }
    public long LocationId { get; set; }
    public Location Location { get; set; }
    public long InventoryId { get; set; }
    public Inventory Inventory { get; set; }
}
