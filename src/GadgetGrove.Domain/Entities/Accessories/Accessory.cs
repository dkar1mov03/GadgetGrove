using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Enums.Accessories;

namespace GadgetGrove.Domain.Entities.Accessories;

public class Accessory : Auditable
{
    public AccessoriesType AccessoriesType { get; set; }
    public string Image {  get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Characteristic { get; set; }

}
