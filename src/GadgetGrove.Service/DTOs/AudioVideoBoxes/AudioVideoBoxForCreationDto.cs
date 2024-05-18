using GadgetGrove.Domain.Enums.AudioVideo;
using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.DTOs.AudioVideoBoxes;

public class AudioVideoBoxForCreationDto
{
    public AudiosModel Audio { get; set; }
    public VideoType VideoType { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime YearOfIssue { get; set; }
}
