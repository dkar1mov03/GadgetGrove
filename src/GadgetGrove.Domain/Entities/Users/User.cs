using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Entities.Authorizations;
using GadgetGrove.Domain.Entities.Orders;

namespace GadgetGrove.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone {  get; set; }
    public long RolId { get; set; }
    public Role Role { get; set; }
    public string PhoneNumber { get; set; }
}
