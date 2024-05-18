using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.WhereHouses;
using GadgetGrove.Service.DTOs.Locations;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Locations;
using GadgetGrove.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Locations;

public class LocationService : ILocationService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Location> _locationRepository;

    public LocationService(IMapper mapper, 
        IRepository<Location> locationRepository)
    {
        _mapper = mapper;
        _locationRepository = locationRepository;
    }

    public async Task<LocationForResultDto> AddAsync(LocationForCreationDto dto)
    {
        var location = await _locationRepository.SelectAll()
            .Where(l => l.Code == dto.Code)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (location is not null)
            throw new GadgetGroveException(409, "Locatin is already exists");

        var mapped = _mapper.Map<Location>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        var result = await _locationRepository.InsertAsync(mapped);

        return _mapper.Map<LocationForResultDto>(result);
    }

    public async Task<LocationForResultDto> ModifyAsync(long id, LocationForCreationDto dto)
    {
        var location = await _locationRepository.SelectAll()
            .Where (l => l.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (location is null)
            throw new GadgetGroveException(404, "Location is not found");

        var modifiedLocation = _mapper.Map(dto, location);
        modifiedLocation.UpdatedAt = DateTime.UtcNow;
        modifiedLocation.UpdatedBy = (long)HttpContextHelper.UserId;

        return _mapper.Map<LocationForResultDto>(modifiedLocation);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var location = await _locationRepository.SelectAll()
            .Where(l => l.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (location is null)
            throw new GadgetGroveException(404, "Location is not found");
        await _locationRepository.DeleteAsync(id);
        location.DeletedBy = (long)HttpContextHelper.UserId;

        return true;
    }

    public async Task<IEnumerable<LocationForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var locations = await _locationRepository.SelectAll()
                .Where(l => !l.IsDeleted)
                .ToPagedList(@params)
                .AsNoTracking()
                .ToListAsync();

        return _mapper.Map<IEnumerable<LocationForResultDto>>(locations);
    }

    public async Task<LocationForResultDto> RetrieveByIdAsync(long id)
    {
        var location = await _locationRepository.SelectAll()
            .Where(l => l.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (location is null)
            throw new GadgetGroveException(404, "Location is not found");

        return _mapper.Map<LocationForResultDto>(location);
    }
}
