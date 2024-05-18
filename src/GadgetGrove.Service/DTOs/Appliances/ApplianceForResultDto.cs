using GadgetGrove.Domain.Enums.Appliances;

namespace GadgetGrove.Service.DTOs.Appliances;

public class ApplianceForResultDto
{
    public long Id { get; set; }
    public AppliancesType Type { get; set; }
    public DateTime YearOfIssue { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Characteristic { get; set; }
}
