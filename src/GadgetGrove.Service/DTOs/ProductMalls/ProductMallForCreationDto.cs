using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Entities.WhereHouses;

namespace GadgetGrove.Service.DTOs.ProductMalls;

public class ProductMallForCreationDto
{
    public int Amount { get; set; }
    public long OrderId { get; set; }
    public long LocationId { get; set; }
}
