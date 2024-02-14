﻿using GadgetGrove.Domain.Commons;

namespace GadgetGrove.Domain.Entities.Addresses;

public class Address : Auditable
{
    public string State { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
