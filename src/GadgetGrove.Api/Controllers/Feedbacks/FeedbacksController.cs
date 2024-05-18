using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Feedbacks;
using GadgetGrove.Service.Interfaces.Feedbacks;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.Feedbacks;

public class FeedbacksController : BaseController
{
    private readonly IFeedbackService _feedbackService;

    public FeedbacksController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] FeedbackForCreationDto dto)
       => Ok(await _feedbackService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    => Ok(await _feedbackService.RetrieveAllAsync(@params));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    => Ok(await _feedbackService.DeleteAsync(id));
}
