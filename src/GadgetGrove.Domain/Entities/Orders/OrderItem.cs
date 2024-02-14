﻿using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Products;
using GadgetGrove.Domain.Entities.WhereHouses;

namespace GadgetGrove.Domain.Entities.Orders;

public class OrderItem : Auditable
{
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public int Amount { get; set; }
    public long LocationId { get; set; }
    public Location Location { get; set; }
    public long InventoryId { get; set; }
    public Inventory Inventory { get; set; }
}
