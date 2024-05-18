using GadgetGrove.Domain.Enums.Locations;

namespace GadgetGrove.Service.DTOs.Locations;

public class LocationForResultDto
{
    public long Id { get; set; }
    public long Code { get; set; }
    public string Description { get; set; }
    public LocationType Type { get; set; }
}
