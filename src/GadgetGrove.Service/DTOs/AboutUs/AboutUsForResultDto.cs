using GadgetGrove.Service.DTOs.AboutUsAssets;

namespace GadgetGrove.Service.DTOs.AboutUs;

public class AboutUsForResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IEnumerable<AboutUsAssetForResultDto> AboutUsAssets { get; set; }
}
