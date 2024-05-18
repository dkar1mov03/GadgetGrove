using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Attachments;
using GadgetGrove.Service.DTOs.Feedbacks;
using System.Collections.Generic;

namespace GadgetGrove.Service.Interfaces.Feedbacks;

public interface IFeedbackService
{
    Task<bool> DeleteAsync(long id);
    Task<FeedbackForResultDto> AddAsync(FeedbackForCreationDto dto);
    Task<IEnumerable<FeedbackForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
