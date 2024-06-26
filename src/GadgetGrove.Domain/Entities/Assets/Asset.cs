﻿using GadgetGrove.Domain.Commons;

namespace GadgetGrove.Domain.Entities.Assets;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}
