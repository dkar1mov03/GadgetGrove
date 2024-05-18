using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Addresses;
using GadgetGrove.Service.DTOs.Addresses;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Addresses;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace GadgetGrove.Service.Services.Addresses;

public class AddressService : IAddressService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Address> _repository;
    public AddressService(IMapper mapper, IRepository<Address> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<AddressForResultDto> AddAsync(AddressForCreationDto address)
    {
        var mapped = _mapper.Map<Address>(address);

        var insertResult = await _repository.InsertAsync(mapped);

        return _mapper.Map<AddressForResultDto>(insertResult);
    }

    public async Task<AddressForResultDto> ModifyAsync(long id, AddressForCreationDto dto)
    {
        var address = await _repository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (address is null)
            throw new GadgetGroveException(404, "Address couldn't find");
        var mapped = _mapper.Map(dto, address);
        mapped.UpdatedAt = DateTime.UtcNow;

        return _mapper.Map<AddressForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var checkAddress = await _repository.SelectAll()
            .Where(ca => ca.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (checkAddress is null)
            throw new GadgetGroveException(404, "Address couldn't find");

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AddressForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var addressQuery = _repository.SelectAll();

        if (addressQuery is null)
            throw new GadgetGroveException(404, "Address not found");

        var addresses = await addressQuery.ToPagedList(@params).ToListAsync();
        return _mapper.Map<IEnumerable<AddressForResultDto>>(addresses);
    }

    public async Task<AddressForResultDto> RetrieveByIdAsync(long id)
    {
        var address = await _repository.SelectAll()
            .Where(ca => ca.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (address is null)
            throw new GadgetGroveException(404, "Address couldn't find");

        return _mapper.Map<AddressForResultDto>(address); ;
    }
}
