using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Enums.Appliances;

namespace GadgetGrove.Domain.Entities.Appliances;

public class Appliance : Auditable
{
    public AppliancesType Type { get; set; }
    public DateTime YearOfIssue { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Characteristic { get; set; }
    public ICollection<Appliance> Appliances { get; set; }
}
