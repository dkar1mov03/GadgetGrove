﻿namespace GadgetGrove.Service.DTOs.Addresses;

public class AddressForResultDto
{
    public long Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
