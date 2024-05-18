using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Enums.Discounts;
using GadgetGrove.Service.DTOs.Discounts;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Discounts;
using GadgetGrove.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Discounts;

public class DiscountService : IDiscountService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Payment> _paymentRepository;
    private readonly IRepository<Discount> _discountRepository;

    public DiscountService(IMapper mapper, 
        IRepository<Payment> paymentRepository, 
        IRepository<Discount> discountRepository)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
        _discountRepository = discountRepository;
    }


    public async Task<DiscountForResultDto> AddAsync(DiscountForCreationDto dto)
    {
        var payment = await _paymentRepository.SelectAll()
            .Where(p => p.Id == dto.PaymentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (payment is null)
            throw new GadgetGroveException(404, "Payment is not found");

        var discounts = await _discountRepository.SelectAll()
            .Where(d => d.State == DiscountState.Active || d.FinishedAt > DateTime.UtcNow)
            .AsNoTracking()
            .ToListAsync();
        if (discounts.Any())
            throw new GadgetGroveException(403, "Discount already exist in this product.");

        var mappedDiscount = _mapper.Map<Discount>(dto);
        var insertedDiscount = await _discountRepository.InsertAsync(mappedDiscount);

        return _mapper.Map<DiscountForResultDto>(insertedDiscount);
    }

    public async  Task<DiscountForResultDto> ModifyAsync(long id, DiscountForUpdateDto dto)
    {
        if (dto.PercentageToCheapen < 1 || dto.PercentageToCheapen > 100)
            throw new GadgetGroveException(401, "PercentageToCheapen must be between 1 and 100.");

        var payment = await _paymentRepository.SelectAll()
            .Where(p => p.Id == dto.PaymentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (payment is null)
            throw new GadgetGroveException(404, "Payment is not found");
        var discount = await _discountRepository.SelectAll()
            .Where(d => d.Id == id && !d.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        var modifiedDiscount = _mapper.Map(dto, discount);
        modifiedDiscount.UpdatedAt = DateTime.UtcNow;
        modifiedDiscount.UpdatedBy = (long)HttpContextHelper.UserId;

        return _mapper.Map<DiscountForResultDto>(modifiedDiscount);

    }

    public async Task<IEnumerable<DiscountForResultDto>> RetrieveAllAsync(PaginationParams @params, DiscountState? state = null)
    {
        var discounts = await _discountRepository.SelectAll()
            .Include(d => d.Payment)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();
        if (discounts is null)
            throw new GadgetGroveException(404, "Discount is not found");
        
        return _mapper.Map<IEnumerable<DiscountForResultDto>>(discounts);
    }

    public async Task<DiscountForResultDto> RetrieveByIdAsnyc(long id)
    {
        var discount = await _discountRepository.SelectAll()
            .Where (d => d.Id == id && !d.IsDeleted && d.State == DiscountState.Active)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (discount is null)
            throw new GadgetGroveException(404, "Discountis not found");

        return _mapper.Map<DiscountForResultDto>(discount);
    }
}
