using GadgetGrove.Domain.Commons;

namespace GadgetGrove.Domain.Entities.Authorizations;

public class Permission : Auditable
{
    public string Name { get; set; }
}
