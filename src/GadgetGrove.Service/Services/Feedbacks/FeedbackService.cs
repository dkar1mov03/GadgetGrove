using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Data.Repositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Attechments;
using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Entities.Orders.Feedbacks;
using GadgetGrove.Service.DTOs.Attachments;
using GadgetGrove.Service.DTOs.Feedbacks;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Attechments;
using GadgetGrove.Service.Interfaces.Feedbacks;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Feedbacks;

public class FeedbackService : IFeedbackService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Feedback> _feedbackRepository;
    //private readonly IRepository<Attachment> _attachmentRepository;
    //private readonly IRepository<FeedbackAttachment> feedbackAttachmentRepository;

    public FeedbackService(IMapper mapper,
        IRepository<Order> orderRepository,
        IRepository<Feedback> feedbackRepository)
        //IRepository<Attachment> attachmentRepository,
        //IRepository<FeedbackAttachment> feedbackAttachmentRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _feedbackRepository = feedbackRepository;
        //_attachmentRepository = attachmentRepository;
        //this.feedbackAttachmentRepository = feedbackAttachmentRepository;
    }

    public async Task<FeedbackForResultDto> AddAsync(FeedbackForCreationDto dto)
    {
        var order = await _feedbackRepository.SelectAll()
            .Where(u => u.Id == dto.OrderId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (order is null)
            throw new GadgetGroveException(404, "User not found");

        var feedback = _mapper.Map<Feedback>(dto);
        feedback.CreatedAt = DateTime.UtcNow;
        var insertFeedback = await _feedbackRepository.InsertAsync(feedback);

        var result = _mapper.Map<FeedbackForResultDto>(insertFeedback);
        return result;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var feedback = await _feedbackRepository.SelectAll()
            .Where(f => f.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (feedback is null)
            throw new GadgetGroveException(404, "Feedback not found");

        await _feedbackRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<FeedbackForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var feedbacks = await _feedbackRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<FeedbackForResultDto>>(feedbacks);
    }
}
