using GadgetGrove.Service.DTOs.Locations;
using GadgetGrove.Service.DTOs.Orders;

namespace GadgetGrove.Service.DTOs.ProductMalls;

public class ProductMallForResultDto
{
    public long Id { get; set; }
    public int Amount { get; set; }
    public long OrderId { get; set; }
    public OrderForResultDto Order { get; set; }
    public long LocationId { get; set; }
    public LocationForResultDto Location { get; set; }
}
