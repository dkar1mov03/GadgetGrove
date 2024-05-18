using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.FeedbackAttachments;

namespace GadgetGrove.Service.Interfaces.FeedbackAttachments;

public interface IFeedbackAttachmentService
{
    Task<bool> RemoveAsync(long id);
    Task<FeedbackAttachmentForResutlDto> AddAsync(FeedbackAttachmentForCreationDto dto);
    Task<IEnumerable<FeedbackAttachmentForResutlDto>> RetrieveAllAsync(PaginationParams @params);
}