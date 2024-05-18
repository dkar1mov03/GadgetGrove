using GadgetGrove.Domain.Entities.Appliances;

namespace GadgetGrove.Domain.Entities.Assets;

public class ApplianceAsset : Asset
{
    public long ApplianceId { get; set; }
    public Appliance Appliance { get; set; }
}
