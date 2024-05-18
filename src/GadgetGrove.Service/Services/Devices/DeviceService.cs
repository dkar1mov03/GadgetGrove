using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Devices;
using GadgetGrove.Service.DTOs.Devices;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Devices;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Devices;

public class DeviceService : IDeviceService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Device> _repository;

    public DeviceService(IMapper mapper, IRepository<Device> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DeviceForResultDto> AddAsync(DeviceForCreationDto dto)
    {
        var device = await _repository.SelectAll()
            .Where(d => d.DeviceModel == dto.DeviceModel)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is not null)
            throw new GadgetGroveException(409, "Device is already exists");

        var mapped = _mapper.Map<Device> (dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _repository.InsertAsync(mapped);

        return _mapper.Map<DeviceForResultDto>(result);
    }

    public async Task<DeviceForResultDto> ModifyAsync(long id, AudioVideoForUpdateDto dto)
    {
        var device = await _repository.SelectAll()
            .Where(d => d.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is null)
            throw new GadgetGroveException(404, "Device is not found");

        var mapped = _mapper.Map(dto, device);
        mapped.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(mapped);

        return _mapper.Map<DeviceForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var device = await _repository.SelectAll()
            .Where(d => d.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is null)
            throw new GadgetGroveException(404, "Device is not found");

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<DeviceForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var devices = await _repository.SelectAll()
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();
        
        return _mapper.Map<IEnumerable<DeviceForResultDto>>(devices);
    }

    public async Task<DeviceForResultDto> RetrieveByIdAsync(long id)
    {
        var device = await _repository.SelectAll()
            .Where(d => d.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is null)
            throw new GadgetGroveException(404, "Device is not found");
        
        return _mapper.Map<DeviceForResultDto>(device);
    }
}
