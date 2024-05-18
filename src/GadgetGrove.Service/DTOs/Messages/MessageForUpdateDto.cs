namespace GadgetGrove.Service.DTOs.Messages;

public class MessageForUpdateDto
{
    public long SenderId { get; set; }
    public long RecipientId { get; set; }
    public string Message { get; set; }
}
