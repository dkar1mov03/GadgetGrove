using GadgetGrove.Domain.Enums.FeedbackStatuses;
using GadgetGrove.Service.DTOs.Attachments;

namespace GadgetGrove.Service.DTOs.Feedbacks;

public class FeedbackForResultDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public string Message { get; set; }
    public FeedbackStatus Status { get; set; }
    public List<AttachmentForResultDto> Attachments { get; set; }
}
