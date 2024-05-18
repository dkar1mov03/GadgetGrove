using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.FeedbackAttachments;
using GadgetGrove.Service.DTOs.Feedbacks;
using GadgetGrove.Service.Interfaces.FeedbackAttachments;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.Feedbacks;

public class FeedbackAttachmentsController : BaseController
{
    private readonly IFeedbackAttachmentService _feedbackAttachmentService;

    public FeedbackAttachmentsController(IFeedbackAttachmentService feedbackAttachmentService)
    {
        _feedbackAttachmentService = feedbackAttachmentService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] FeedbackAttachmentForCreationDto dto)
       => Ok(await _feedbackAttachmentService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    => Ok(await _feedbackAttachmentService.RetrieveAllAsync(@params));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    => Ok(await _feedbackAttachmentService.RemoveAsync(id));
}
