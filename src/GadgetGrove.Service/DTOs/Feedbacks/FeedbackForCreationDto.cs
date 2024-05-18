using GadgetGrove.Domain.Entities.Orders.Feedbacks;
using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Enums.FeedbackStatuses;

namespace GadgetGrove.Service.DTOs.Feedbacks;

public class FeedbackForCreationDto
{
    public string Message { get; set; }
    public long OrderId { get; set; }
}
