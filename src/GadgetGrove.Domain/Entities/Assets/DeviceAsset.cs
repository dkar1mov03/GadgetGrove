using GadgetGrove.Domain.Entities.Devices;

namespace GadgetGrove.Domain.Entities.Assets;

public class DeviceAsset : Asset
{
    public long DeviceId { get; set; }
    public Device Device { get; set; }
}
