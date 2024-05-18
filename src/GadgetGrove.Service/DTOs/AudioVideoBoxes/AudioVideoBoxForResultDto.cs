using GadgetGrove.Domain.Enums.AudioVideo;

namespace GadgetGrove.Service.DTOs.AudioVideoBoxes;

public class AudioVideoBoxForResultDto
{
    public long Id { get; set; }
    public AudiosModel Audio { get; set; }
    public VideoType VideoType { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime YearOfIssue { get; set; }
}
