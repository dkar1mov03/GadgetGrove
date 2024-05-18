using GadgetGrove.Domain.Enums.Appliances;
using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.DTOs.Appliances;

public class ApplianceForUpdateDto
{
    public AppliancesType Type { get; set; }
    public DateTime YearOfIssue { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Characteristic { get; set; }
}
