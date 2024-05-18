using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Accessories;
using GadgetGrove.Domain.Entities.Assets;
using GadgetGrove.Service.DTOs.AccessoryAssets;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.AccessoryAssets;
using GadgetGrove.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace GadgetGrove.Service.Services.AccessoryAssets;

public class AccessoryAssetService : IAccessoryAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Accessory> _accessoryRepository;
    private readonly IRepository<AccessoryAsset> _assetRepository;

    public AccessoryAssetService(IMapper mapper, 
        IRepository<Accessory> accessoryRepository,
        IRepository<AccessoryAsset> assetRepository)
    {
        _mapper = mapper;
        _accessoryRepository = accessoryRepository;
        _assetRepository = assetRepository;
    }

    public async Task<AccessoryAssetForResultDto> AddAsync(long AccessoryId, IFormFile file)
    {
        var accessory = await _accessoryRepository.SelectAll()
            .Where(a => a.Id == AccessoryId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (accessory is null)
            throw new GadgetGroveException(404, "Accerroys is not found");
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        var rootPath = Path.Combine(EnvironmentContextHelper.WebRootPath, "Media", "Accessory", "Images", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new AccessoryAsset()
        {
            AccessoryId = AccessoryId,
            Name = file.Name,
            Size = file.Length,
            Type = file.ContentType,
            CreatedAt = DateTime.UtcNow,
            Extension = Path.GetExtension(file.FileName),
            Path = Path.Combine("Media", "Accessory", "Images", file.FileName)
        };

        var result = await _assetRepository.InsertAsync(mappedAsset);

        return _mapper.Map<AccessoryAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long AccessoryId, long id)
    {
        var accessory = await _accessoryRepository.SelectAll()
            .Where(a => a.Id ==  AccessoryId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (accessory is null)
            throw new GadgetGroveException(404, "Accessory is not found");
        var asset = await _assetRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (asset is null)
            throw new GadgetGroveException(404, "Asset is not found");

        return await _assetRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AccessoryAssetForResultDto>> RetrieveAllAsync(long AccessoryId, PaginationParams @params)
    {
        var accessory = await _accessoryRepository.SelectAll()
            .Where(a => a.Id == AccessoryId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (accessory is null)
            throw new GadgetGroveException(404, "Accessory is not found");
        var asset = await _assetRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<AccessoryAssetForResultDto>>(asset);
    }

    public async Task<AccessoryAssetForResultDto> RetrieveByIdASync(long AccessoryId, long id)
    {
        var accessory = await _accessoryRepository.SelectAll()
            .Where(a => a.Id == AccessoryId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (accessory is null)
            throw new GadgetGroveException(404, "Accessory is not found");
        var asset = await _assetRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (asset is null)
            throw new GadgetGroveException(404, "Asset is not found");

        return _mapper.Map<AccessoryAssetForResultDto>(asset);
    }
}
