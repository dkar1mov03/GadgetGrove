﻿namespace GadgetGrove.Service.DTOs.AudioVideoAssets;

public class AudioVideoBoxAssetForResultDto
{
    public long Id { get; set; }
    public long VideoAudioBoxId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}
