using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Assets;
using GadgetGrove.Domain.Entities.Devices;
using GadgetGrove.Service.DTOs.DeviceAssets;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.DeviceAssets;
using GadgetGrove.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace GadgetGrove.Service.Services.DeviceAssets;

public class DeviceAssetService : IDeviceAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Device> _deviceRepository;
    private readonly IRepository<DeviceAsset> _deviceAssetRepository;

    public DeviceAssetService(IMapper mapper, 
        IRepository<Device> deviceRepository, 
        IRepository<DeviceAsset> deviceAssetRepository)
    {
        _mapper = mapper;
        _deviceRepository = deviceRepository;
        _deviceAssetRepository = deviceAssetRepository;
    }

    public async Task<DeviceAssetForResultDto> AddAsync(long deviceid, IFormFile file)
    {
        var device = await _deviceRepository.SelectAll()
            .Where(d => d.Id == deviceid)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is null)
            throw new GadgetGroveException(404, "Device is not found");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        var rootPath = Path.Combine(EnvironmentContextHelper.WebRootPath, "Media", "Device", "Images", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new DeviceAsset()
        {
            DeviceId = deviceid,
            Name = file.Name,
            Size = file.Length,
            Type = file.ContentType,
            CreatedAt = DateTime.UtcNow,
            Extension = Path.GetExtension(file.FileName),
            Path = Path.Combine("Media", "Device", "Images", file.FileName)
        };

        var result = await _deviceAssetRepository.InsertAsync(mappedAsset);

        return _mapper.Map<DeviceAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long deviceid, long id)
    {
        var device = await _deviceRepository.SelectAll()
            .Where(d => d.Id == deviceid)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is null)
            throw new GadgetGroveException(404, "Device is not found");
        var asset = await _deviceAssetRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (asset is null)
            throw new GadgetGroveException(404, "Asset is not null");

        return await _deviceAssetRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<DeviceAssetForResultDto>> RetrieveAllAsync(long deviceid, PaginationParams @params)
    {
        var device = await _deviceRepository.SelectAll()
            .Where(d => d.Id == deviceid)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is null)
            throw new GadgetGroveException(404, "Device is not found");
        var asset = await _deviceAssetRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<DeviceAssetForResultDto>>(asset);
    }

    public async Task<DeviceAssetForResultDto> RetrieveByIdAsync(long deviceid, long id)
    {
        var device = await _deviceRepository.SelectAll()
            .Where(d => d.Id == deviceid)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (device is null)
            throw new GadgetGroveException(404, "Device is not found");
        var asset = await _deviceAssetRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (asset is null)
            throw new GadgetGroveException(404, "Asset is not null");

        return _mapper.Map<DeviceAssetForResultDto>(asset);
    }
}
