using GadgetGrove.Domain.Commons;

namespace GadgetGrove.Domain.Entities.Authorizations;

public class Role : Auditable
{
    public string Name { get; set; }
}