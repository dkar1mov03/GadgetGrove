namespace GadgetGrove.Service.DTOs.AccessoryAssets;

public class AccessoryAssetForResultDto
{
    public long Id { get; set; }
    public long AccessoryId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}
