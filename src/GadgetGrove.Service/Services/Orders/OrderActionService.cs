using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Enums.OrderStatuses;
using GadgetGrove.Service.DTOs.OrderActions;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GadgetGrove.Service.Services.Orders;

public class OrderActionService : IOrderActionService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<OrderAction> _orderActionRepository;

    public OrderActionService(IMapper mapper, 
        IRepository<Order> orderRepository,
        IRepository<OrderAction> orderActionRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _orderActionRepository = orderActionRepository;
    }

    public async Task<OrderActionForResultDto> AddAsync(OrderActionForCreationDto dto)
    {
        var order = await _orderRepository.SelectAll()
            .Where(o => o.Id == dto.OrderId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (order is null)
            throw new GadgetGroveException(404, "Order is not found");
        var orderAction = await _orderActionRepository.SelectAll()
            .Where(oa => oa.ApproximateFinishTime == dto.ApproximateFinishTime)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (orderAction is not null)
            throw new GadgetGroveException(409, "OrderAction is already exists");
        var mapped = _mapper.Map<OrderAction>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _orderActionRepository.InsertAsync(mapped);

        return _mapper.Map<OrderActionForResultDto>(result);
    }

    public async Task<OrderActionForResultDto> ModifyAsync(long id, OrderActionForUpdateDto dto)
    {
        var orderAction = await _orderActionRepository.SelectAll()
            .Where (o => o.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (orderAction is null)
            throw new GadgetGroveException(404, "OrderAction is asready exists");

        return _mapper.Map<OrderActionForResultDto>(orderAction);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var orderAction = await _orderActionRepository.SelectAll()
            .Where(o => o.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (orderAction is null)
            throw new GadgetGroveException(404, "OrderAction is not found");

        return await _orderActionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrderActionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var orderActions = await _orderActionRepository.SelectAll()
            .Include(o => o.Order)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrderActionForResultDto>>(orderActions); 
    }

    public async Task<OrderActionForResultDto> RetrieveByIdAsync(long id)
    {
        var orderAction = await _orderActionRepository.SelectAll()
            .Where(o => o.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (orderAction is null)
            throw new GadgetGroveException(404, "OrderAction is not found");

        return _mapper.Map<OrderActionForResultDto>(orderAction);
    }
}
