﻿using GadgetGrove.Domain.Enums.Devices;
using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.DTOs.Devices;

public class DeviceForCreationDto
{
    public Name Name { get; set; }
    public decimal Price { get; set; }
    public DateTime YearOfIssue { get; set; }
    public string Description { get; set; }
    public CameraMp CameraMp { get; set; }
    public Color Color { get; set; }
    public DevicesModel DeviceModel { get; set; }
    public Frequency Frequency { get; set; }
    public Memory Memory { get; set; }
    public Processor Processor { get; set; }
    public Ram Ram { get; set; }
    public ScreenInch ScreenInch { get; set; }
    public ScreenType ScreenType { get; set; }
    public SIM SIM { get; set; }
}
