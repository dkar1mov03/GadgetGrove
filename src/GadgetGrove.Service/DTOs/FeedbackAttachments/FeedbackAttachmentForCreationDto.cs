using GadgetGrove.Domain.Entities.Orders.Feedbacks;

namespace GadgetGrove.Service.DTOs.FeedbackAttachments;

public class FeedbackAttachmentForCreationDto
{
    public long FeedbackId { get; set; }
    public long AttachmentId { get; set; }
}
