using GadgetGrove.Domain.Enums.Locations;
using System.ComponentModel.DataAnnotations;

namespace GadgetGrove.Service.DTOs.Locations;

public class LocationForCreationDto
{
    public long Code { get; set; }
    public string Description { get; set; }
    public LocationType Type { get; set; }
}
