using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Addresses;
using GadgetGrove.Domain.Entities.Users;

namespace GadgetGrove.Domain.Entities.WhereHouses;

public class Inventory : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long AddressId { get; set; }
    public Address Address { get; set; }
    public long? OwnerId { get; set; }
    public User Owner { get; set; }
}
