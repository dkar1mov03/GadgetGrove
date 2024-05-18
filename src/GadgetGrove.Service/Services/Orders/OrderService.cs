using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Accessories;
using GadgetGrove.Domain.Entities.Addresses;
using GadgetGrove.Domain.Entities.Appliances;
using GadgetGrove.Domain.Entities.Devices;
using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Entities.VideoAudioBoxs;
using GadgetGrove.Service.DTOs.Orders;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Orders;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Device> _deviceRepository;
    private readonly IRepository<Address> _addressRepository;
    private readonly IRepository<Payment> _paymentRepository;
    private readonly IRepository<Appliance> _applianceRepository;
    private readonly IRepository<Accessory> _accessoryRepository;
    private readonly IRepository<VideoAudiBox> _videoAudiBoxRepository;

    public OrderService(IMapper mapper,
        IRepository<Address> addressRepository,
        IRepository<Payment> paymentRepository,
        IRepository<Order> orderRepository,
        IRepository<Device> deviceRepository,
        IRepository<Appliance> applianceRepository,
        IRepository<Accessory> accessoryRepository,
        IRepository<VideoAudiBox> videoAudiBoxRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
        _paymentRepository = paymentRepository;
        _orderRepository = orderRepository;
        _deviceRepository = deviceRepository;
        _applianceRepository = applianceRepository;
        _accessoryRepository = accessoryRepository;
        _videoAudiBoxRepository = videoAudiBoxRepository;
    }

    public async Task<OrderForResultDto> AddAsync(OrderForCreationDto dto)
    {
        int count = 0;
        var device = await _deviceRepository.SelectAll()
            .Where(od => od.Id == dto.DeviceId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is not null)
            count++;
        var appliance = await _applianceRepository.SelectAll()
            .Where(oa => oa.Id == dto.ApplianceId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (appliance is not null)
            count++;    
        var accessory = await _accessoryRepository.SelectAll()
            .Where(oa => oa.Id == dto.AccessoryId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (accessory is not null)
            count++;
        if (count < 0)
            throw new GadgetGroveException(404, "Products not found");

        var order = await _orderRepository.SelectAll()
            .Where(o => o.Status == dto.Status)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (order is not null)
            throw new GadgetGroveException(409, "Order is already exists");
        var mapper = _mapper.Map<Order>(dto);
        mapper.CreatedAt = DateTime.UtcNow;
        var result = await _orderRepository.InsertAsync(mapper);

        return _mapper.Map<OrderForResultDto>(result);
    }

    public async Task<OrderForResultDto> ModifyAsync(long id, OrderForUpdateDto dto)
    {
        int count = 0;
        var device = await _deviceRepository.SelectAll()
            .Where(od => od.Id == dto.DeviceId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is not null)
            count++;
        var appliance = await _applianceRepository.SelectAll()
            .Where(oa => oa.Id == dto.ApplianceId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (appliance is not null)
            count++;
        var accessory = await _accessoryRepository.SelectAll()
            .Where(oa => oa.Id == dto.AccessoryId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (accessory is not null)
            count++;
        if (count < 0)
            throw new GadgetGroveException(404, "Products not found");

        var order = await _orderRepository.SelectAll()
            .Where(o => o.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (order is  null)
            throw new GadgetGroveException(404, "Order is not found");

        var mapper = _mapper.Map(dto, order);
        mapper.UpdatedAt = DateTime.UtcNow;

        var result = await _orderRepository.UpdateAsync(mapper);

        return _mapper.Map<OrderForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var order = await _orderRepository.SelectAll()
            .Where(o => o.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (order is null)
            throw new GadgetGroveException(404, "Order is not found");

        return await _orderRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var orders = await _orderRepository.SelectAll()
            .Include(o => o.Appliance)
            .Include(o => o.VideoAudiBox)
            .Include(o => o.Accessory)
            .Include(o => o.Address)
            .Include(o => o.Device)
            .Include(o => o.Payment)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrderForResultDto>>(orders);
    }

    public async Task<OrderForResultDto> RetrieveByIdAsync(long id)
    {
        var order = await _orderRepository.SelectAll()
            .Where(o => o.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (order is null)
            throw new GadgetGroveException(404, "Order is not found");

        return _mapper.Map<OrderForResultDto>(order);
    }
}
