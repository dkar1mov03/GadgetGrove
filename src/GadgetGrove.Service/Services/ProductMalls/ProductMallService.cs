using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Entities.WhereHouses;
using GadgetGrove.Service.DTOs.ProductMalls;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.ProductMalls;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace GadgetGrove.Service.Services.ProductMalls;

public class ProductMallService : IProductMallService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Location> _locationRepository;
    private readonly IRepository<ProductMallInventoryAssignment> _productMallInventoryAssignmentRepository;

    public ProductMallService(IMapper mapper,
        IRepository<Order> orderRepository,
        IRepository<Location> locationRepository,
        IRepository<ProductMallInventoryAssignment> productMallInventoryAssignmentRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _locationRepository = locationRepository;
        _productMallInventoryAssignmentRepository = productMallInventoryAssignmentRepository;
    }

    public async Task<ProductMallForResultDto> AddAsync(ProductMallForCreationDto dto)
    {
        var order = await _orderRepository.SelectAll()
            .Where(po => po.Id == dto.OrderId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (order is null)
            throw new GadgetGroveException(404, "Order is not found");
        var location = await _locationRepository.SelectAll()
            .Where(pl => pl.Id == dto.LocationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (location is null)
            throw new GadgetGroveException(404, "Location is not found");
        var productMall = await _productMallInventoryAssignmentRepository.SelectAll()
            .Where(p => p.Amount == dto.Amount)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (productMall is not null)
            throw new GadgetGroveException(409, "ProductMall is already exists");
        var mapped = _mapper.Map<ProductMallInventoryAssignment>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _productMallInventoryAssignmentRepository.InsertAsync(mapped);

        return  _mapper.Map<ProductMallForResultDto>(result);
    }

    public async Task<ProductMallForResultDto> ModifyAsync(long id, ProductMallForUpdateDto dto)
    {
        var order = await _orderRepository.SelectAll()
            .Where(po => po.Id == dto.OrderId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (order is null)
            throw new GadgetGroveException(404, "Order is not found");
        var location = await _locationRepository.SelectAll()
            .Where(pl => pl.Id == dto.LocationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (location is null)
            throw new GadgetGroveException(404, "Location is not found");
        var productMall = await _productMallInventoryAssignmentRepository.SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (productMall is  null)
            throw new GadgetGroveException(404, "ProductMall is not found");
        var mapped = _mapper.Map(dto,productMall);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _productMallInventoryAssignmentRepository.UpdateAsync(mapped);

        return _mapper.Map<ProductMallForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var productMall = await _productMallInventoryAssignmentRepository.SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (productMall is null)
            throw new GadgetGroveException(409, "ProductMall is not found");

        return await _productMallInventoryAssignmentRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductMallForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var productMall = await _productMallInventoryAssignmentRepository.SelectAll()
            .Include(p => p.Order)
            .Include(p => p.Location)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProductMallForResultDto>>(productMall);

    }

    public async Task<ProductMallForResultDto> RetrieveByIdAsync(long id)
    {
        var productMall = await _productMallInventoryAssignmentRepository.SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (productMall is null)
            throw new GadgetGroveException(409, "ProductMall is not found");

        return _mapper.Map<ProductMallForResultDto>(productMall);
    }
}
