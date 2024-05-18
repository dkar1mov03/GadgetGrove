using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Accessories;
using GadgetGrove.Service.DTOs.Accessories;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Accessories;
using GadgetGrove.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Accessories;

public class AccessoryService : IAccessoryService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Accessory> _repository;

    public AccessoryService(IMapper mapper, 
        IRepository<Accessory> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<AccessoryForResultDto> AddAsync(AccessoryForCreationDto dto)
    {
        var accessory = await _repository.SelectAll()
            .Where(a => a.Price == dto.Price)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (accessory is not null)
            throw new GadgetGroveException(409, "Accessory is already exists");

        var mapped = _mapper.Map<Accessory>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _repository.InsertAsync(mapped);

        return _mapper.Map<AccessoryForResultDto>(result);

    }

    public async Task<AccessoryForResultDto> ModifyAsync(long id, AccessoryForUpdateDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is null)
            throw new GadgetGroveException(404, "Accessory is not found");

        var mapped = this._mapper.Map(dto, entity);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mapped);
        return _mapper.Map<AccessoryForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .Where(e => e.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (entity == null)
            throw new GadgetGroveException(400, "Accessory is not found");

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AccessoryForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var entities = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .ToPagedList(@params)
        .AsNoTracking()
        .ToListAsync();

        return _mapper.Map<IEnumerable<AccessoryForResultDto>>(entities);
    }

    public async Task<AccessoryForResultDto> RetrieveByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .Where(e => e.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (entity is null)
            throw new GadgetGroveException(400, "Accessory is not found ");

        var mappedEntity = _mapper.Map<AccessoryForResultDto>(entity);

        return mappedEntity;
    }
}
