namespace GadgetGrove.Service.DTOs.DeviceAssets;

public class DeviceAssetForResultDto
{
    public long Id { get; set; }
    public long DeviceId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}
