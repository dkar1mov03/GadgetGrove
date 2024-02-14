using GadgetGrove.Domain.Commons;

namespace GadgetGrove.Domain.Entities.Attechments;

public class Attachment : Auditable
{
    public string FilePath { get; set; }
    public string FileName { get; set; }
}
