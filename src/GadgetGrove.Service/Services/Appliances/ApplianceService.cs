using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Appliances;
using GadgetGrove.Service.DTOs.Appliances;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Appliances;
using GadgetGrove.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Appliances;

public class ApplianceService : IApplianceService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Appliance> _repository;

    public ApplianceService(IMapper mapper, 
        IRepository<Appliance> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ApplianceForResultDto> AddAync(ApplianceForCreationDto dto)
    {
        var appliance = await _repository.SelectAll()
            .Where(a => a.Characteristic.ToLower() == dto.Characteristic.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (appliance is not null)
            throw new GadgetGroveException(409, "Appliance is already exist");

        var mapped = _mapper.Map<Appliance>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _repository.InsertAsync(mapped);

        return _mapper.Map<ApplianceForResultDto>(result);
    }

    public async Task<ApplianceForResultDto> ModifyAsync(long id, ApplianceForUpdateDto dto)
    {
        var appliance = await _repository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (appliance is null)
            throw new GadgetGroveException(404, "Appliance is not found");

        var mapped = _mapper.Map(dto, appliance);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mapped);

        return _mapper.Map<ApplianceForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var applaince = await _repository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .FirstOrDefaultAsync();

        if (applaince is null)
            throw new GadgetGroveException(404, "Appliance is not found");

        return await _repository.DeleteAsync(id);
    }

    public async Task<ApplianceForResultDto> RetriaveByIdAsync(long id)
    {
        var appliance = await _repository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (appliance is null)
            throw new GadgetGroveException(404, "Appliance is not found");

        return _mapper.Map<ApplianceForResultDto>(appliance);
    }

    public async Task<IEnumerable<ApplianceForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var appliances = await _repository.SelectAll()
            .Where(r => r.IsDeleted == false)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<ApplianceForResultDto>>(appliances);
    }
}
