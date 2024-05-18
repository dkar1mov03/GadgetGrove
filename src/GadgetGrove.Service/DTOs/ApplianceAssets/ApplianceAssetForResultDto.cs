namespace GadgetGrove.Service.DTOs.ApplianceAssets;

public class ApplianceAssetForResultDto
{
    public long Id { get; set; }
    public long ApplianceId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}
