using GadgetGrove.Domain.Entities.AboutUs;
using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.DTOs.AboutUsAssets;

public class AboutUsAssetForCreationDto
{
    public long AboutUsId { get; set; }
    public IFormFile Image { get; set; }
}
