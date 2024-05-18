using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Enums.AudioVideo;

namespace GadgetGrove.Domain.Entities.VideoAudioBoxs;

public class VideoAudiBox : Auditable
{
    public AudiosModel Audio { get; set; }
    public VideoType VideoType { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime YearOfIssue { get; set; }
}
