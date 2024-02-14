using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Enums.Locations;

namespace GadgetGrove.Domain.Entities.WhereHouses;

public class Location : Auditable
{
    public long Code { get; set; }
    public LocationType Type { get; set; }
    public string Description { get; set; }
}
