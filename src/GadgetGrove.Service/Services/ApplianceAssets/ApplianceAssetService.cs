using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Appliances;
using GadgetGrove.Domain.Entities.Assets;
using GadgetGrove.Service.DTOs.ApplianceAssets;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.ApplianceAssets;
using GadgetGrove.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.ApplianceAssets;

public class ApplianceAssetService : IApplianceAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Appliance> _applianceRepository;
    private readonly IRepository<ApplianceAsset> _applianceAssetRepository;

    public ApplianceAssetService(IMapper mapper, 
        IRepository<Appliance> applianceRepository,
        IRepository<ApplianceAsset> applianceAssetRepository)
    {
        _mapper = mapper;
        _applianceRepository = applianceRepository;
        _applianceAssetRepository = applianceAssetRepository;
    }

    public async Task<ApplianceAssetForResultDto> AddAsync(long ApplianceId, IFormFile file)
    {
        var appliance = await _applianceRepository.SelectAll()
            .Where(a => a.Id == ApplianceId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (appliance is null)
            throw new GadgetGroveException(404, "Appliance is not found");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        var rootPath = Path.Combine(EnvironmentContextHelper.WebRootPath, "Media", "Appliance", "Images", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new ApplianceAsset()
        {
            ApplianceId = ApplianceId,
            Name = file.Name,
            Size = file.Length,
            Type = file.ContentType,
            CreatedAt = DateTime.UtcNow,
            Extension = Path.GetExtension(file.FileName),
            Path = Path.Combine("Media", "Appliance", "Images", file.FileName)
        };

        var result = await _applianceAssetRepository.InsertAsync(mappedAsset);

        return _mapper.Map<ApplianceAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long ApplianceId, long id)
    {
        var appliance = await _applianceAssetRepository.SelectAll()
            .Where(a => a.Id == ApplianceId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (appliance is null)
            throw new GadgetGroveException(404, "Appliance is not found");

        var asset = await _applianceAssetRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (asset is null)
            throw new GadgetGroveException(404, "Asset is not found");
        
        return await _applianceAssetRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ApplianceAssetForResultDto>> RetrieveAllAsync(long ApplianceId, PaginationParams @params)
    {
        var appliance = await _applianceAssetRepository.SelectAll()
            .Where(a => a.Id == ApplianceId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (appliance is null)
            throw new GadgetGroveException(404, "Appliance is not found");

        var asset = await _applianceAssetRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<ApplianceAssetForResultDto>>(asset);
    }

    public async Task<ApplianceAssetForResultDto> RetrieveByIdAsync(long ApplianceId, long id)
    {
        var appliance = await _applianceAssetRepository.SelectAll()
            .Where(a => a.Id == ApplianceId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (appliance is null)
            throw new GadgetGroveException(404, "Appliance is not found");

        var asset = await _applianceAssetRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (asset is null)
            throw new GadgetGroveException(404, "Asset is not found");

        return _mapper.Map<ApplianceAssetForResultDto>(asset);
    }
}
