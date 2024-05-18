using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Attechments;
using GadgetGrove.Domain.Entities.Orders.Feedbacks;
using GadgetGrove.Service.DTOs.FeedbackAttachments;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.FeedbackAttachments;
using Microsoft.EntityFrameworkCore;


namespace GadgetGrove.Service.Services.FeedbackAttachments;

public class FeedbackAttachmentService : IFeedbackAttachmentService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Feedback> _feedbackRepository;
    private readonly IRepository<Attachment> _attachmentRepository;
    private readonly IRepository<FeedbackAttachment> _feedbackAttachmentsRepository;

    public FeedbackAttachmentService(IMapper mapper,
        IRepository<Feedback> feedbackRepository, 
        IRepository<Attachment> attachmentRepository, 
        IRepository<FeedbackAttachment> feedbackAttachmentsRepository)
    {
        _mapper = mapper;
        _feedbackRepository = feedbackRepository;
        _attachmentRepository = attachmentRepository;
        _feedbackAttachmentsRepository = feedbackAttachmentsRepository;
    }

    public async Task<FeedbackAttachmentForResutlDto> AddAsync(FeedbackAttachmentForCreationDto dto)
    {
        var feedback = await _feedbackRepository.SelectAll()
            .Where(f => f.Id == dto.FeedbackId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (feedback is null)
            throw new GadgetGroveException(404, "Feedback is not found");
        var attachment = await _attachmentRepository.SelectAll()
            .Where(a =>  a.Id == dto.AttachmentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (attachment is null)
            throw new GadgetGroveException(404, "Attachment is not found");

        var mapped = _mapper.Map<FeedbackAttachment>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        await _feedbackAttachmentsRepository.InsertAsync(mapped);

        return _mapper.Map<FeedbackAttachmentForResutlDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var feedbackAttachment = await _feedbackAttachmentsRepository.SelectAll()
            .Where(f => f.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (feedbackAttachment is null)
            throw new GadgetGroveException(404, "Feedback not found");

        await _feedbackAttachmentsRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<FeedbackAttachmentForResutlDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var feedbackAttachments = await _feedbackAttachmentsRepository.SelectAll()
             .ToPagedList(@params)
             .AsNoTracking()
             .ToListAsync();

        return _mapper.Map<IEnumerable<FeedbackAttachmentForResutlDto>>(feedbackAttachments);
    }
}
