using GadgetGrove.Domain.Entities.VideoAudioBoxs;

namespace GadgetGrove.Domain.Entities.Assets;

public class AudioVideoBoxAsset : Asset
{
    public long VideoAudioId { get; set; }
    public VideoAudiBox VideoAudiBox { get; set; }
}
