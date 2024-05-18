using GadgetGrove.Service.DTOs.Attachments;

namespace GadgetGrove.Service.DTOs.Feedbacks;

public class FeedbackForUpdateDto
{
    public long OrderId { get; set; }
    public string Message { get; set; }
    public IEnumerable<AttachmentForCreationDto> Attachments { get; set; }
}
