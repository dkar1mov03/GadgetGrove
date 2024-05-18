using GadgetGrove.Domain.Commons;
using GadgetGrove.Domain.Enums.FeedbackStatuses;

namespace GadgetGrove.Domain.Entities.Orders.Feedbacks;

public class Feedback : Auditable
{
    public string Message { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public FeedbackStatus Status { get; set; } = FeedbackStatus.notseen;
    public ICollection<FeedbackAttachment> Attachments { get; set; }
}
