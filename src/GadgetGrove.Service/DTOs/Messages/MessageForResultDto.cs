using GadgetGrove.Service.DTOs.Users;

namespace GadgetGrove.Service.DTOs.Messages;

public class MessageForResultDto
{
    public long Id { get; set; }
    public long SenderId { get; set; }
    public long RecipientId { get; set; }
    public UserForResultDto Sender { get; set; }
    public string Message { get; set; }
}
