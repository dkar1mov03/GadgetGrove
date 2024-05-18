using GadgetGrove.Domain.Enums.Accessories;
using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.DTOs.Accessories;

public class AccessoryForCreationDto
{
    public AccessoriesType AccessoriesType { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Characteristic { get; set; }
    public DateTime YearOfIssue { get; set; }
}
