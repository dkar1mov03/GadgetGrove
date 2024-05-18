using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Entities.WhereHouses;
using GadgetGrove.Service.DTOs.Locations;
using GadgetGrove.Service.DTOs.Orders;

namespace GadgetGrove.Service.DTOs.ProductMalls;

public class ProductMallForUpdateDto
{
    public int Amount { get; set; }
    public long OrderId { get; set; }
    public long LocationId { get; set; }
}
