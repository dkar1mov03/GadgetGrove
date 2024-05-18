namespace GadgetGrove.Domain.Commons;

public abstract class Auditable
{
    public long Id { get; set; }
    public long UpdatedBy { get; set; }
    public long DeletedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
