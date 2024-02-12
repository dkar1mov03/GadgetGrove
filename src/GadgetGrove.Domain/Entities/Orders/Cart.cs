using GadgetGrove.Domain.Commons;

namespace GadgetGrove.Domain.Entities.Orders;

public class Cart : Auditable
{
    public long UserId { get; set; }
    public ICollection<CartItem> Items { get; set; }
}
