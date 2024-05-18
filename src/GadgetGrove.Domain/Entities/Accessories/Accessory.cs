using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Assets;
using GadgetGrove.Domain.Enums.Accessories;

namespace GadgetGrove.Domain.Entities.Accessories;

public class Accessory : Auditable
{
    public AccessoriesType AccessoriesType { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Characteristic { get; set; }
    public DateTime YearOfIssue { get; set; } = DateTime.Now;
    public ICollection<AccessoryAsset> AccessoryAssets { get; set; }
}
