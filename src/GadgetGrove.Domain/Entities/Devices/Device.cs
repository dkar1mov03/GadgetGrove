using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Enums.Devices;

namespace GadgetGrove.Domain.Entities.Devices;

public class Device : Auditable
{
    public string Image {  get; set; }
    public Name Name { get; set; }
    public decimal Price { get; set; }
    public DateTime YearOfIssue { get; set; }
    public DevicesModel DevicesModel { get; set; }

}
