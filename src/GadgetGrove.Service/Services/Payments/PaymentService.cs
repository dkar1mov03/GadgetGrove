using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Attechments;
using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Entities.Users;
using GadgetGrove.Domain.Enums.PaymentStatuses;
using GadgetGrove.Service.DTOs.Payments;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Payments;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Payments;

public class PaymentService : IPaymentService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Payment> _repository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Attachment> _attachmentRepository;

    public PaymentService(IMapper mapper, 
        IRepository<User> userRepository, 
        IRepository<Attachment> attachmentRepository,
        IRepository<Payment> repository)
    {
        _mapper = mapper;
        _repository = repository;
        _userRepository = userRepository;
        _attachmentRepository = attachmentRepository;
    }

    public async Task<PaymentForResultDto> AddAsync(PaymentForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null)
            throw new GadgetGroveException(404, "User is not found");
        var attachment = await _attachmentRepository.SelectAll()
            .Where(a => a.Id == dto.FileId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (attachment is null)
            throw new GadgetGroveException(404, "Attachment is not found");
        var payment = await _repository.SelectAll()
            .Where(p => p.Amount == dto.Amount)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (payment is not null)
            throw new GadgetGroveException(409, "Payment is already exists");

        var mapped = _mapper.Map<Payment>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _repository.InsertAsync(mapped);

        return _mapper.Map<PaymentForResultDto>(result);
    }

    public async Task<PaymentForResultDto> ChangeStatusAsync(long id, PaymentStatus status)
    {
        var payment = await _repository.SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (payment is null)
            throw new GadgetGroveException(404, "Payment is not found");

        payment.Status = status;
        payment = await _repository.UpdateAsync(payment);

        return _mapper.Map<PaymentForResultDto>(payment);
    }

    public async Task<PaymentForResultDto> ModifyAsync(long id, PaymentForUpdateDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null)
            throw new GadgetGroveException(404, "User is not found");
        var attachment = await _attachmentRepository.SelectAll()
            .Where(a => a.Id == dto.FileId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (attachment is null)
            throw new GadgetGroveException(404, "Attachment is not found");
        var payment = await _repository.SelectAll()
            .Where(p => p.Amount == dto.Amount)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (payment is null)
            throw new GadgetGroveException(404, "Payment is not found");
        var mapped = _mapper.Map(dto,payment);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mapped);

        return _mapper.Map<PaymentForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var payment = await _repository.SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (payment is null)
            throw new GadgetGroveException(404, "Payment is not found");

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PaymentForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var payment = await _repository.SelectAll()
            .Include(p => p.User)
            .Include(p => p.File)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<PaymentForResultDto>>(payment);
    }

    public async Task<PaymentForResultDto> RetrieveByIdAsync(long id)
    {
        var payment = await _repository.SelectAll()
            .Where(p => p.Id == id)
            .Include(p => p.User)
            .Include(p => p.File)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (payment is null)
            throw new GadgetGroveException(404, "Payment is not found");

        return _mapper.Map<PaymentForResultDto>(payment);
    }
}
