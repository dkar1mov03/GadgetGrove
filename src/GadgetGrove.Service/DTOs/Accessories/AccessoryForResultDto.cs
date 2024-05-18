using GadgetGrove.Domain.Enums.Accessories;

namespace GadgetGrove.Service.DTOs.Accessories;

public class AccessoryForResultDto
{
    public long Id { get; set; }
    public AccessoriesType AccessoriesType { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Characteristic { get; set; }
    public DateTime YearOfIssue { get; set; }
}
