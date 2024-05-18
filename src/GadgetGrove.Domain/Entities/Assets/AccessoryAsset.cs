using GadgetGrove.Domain.Entities.Accessories;

namespace GadgetGrove.Domain.Entities.Assets;

public class AccessoryAsset : Asset
{
    public long AccessoryId { get; set; }
    public Accessory Accessory { get; set; }
}
