using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Authorizations;
using GadgetGrove.Service.DTOs.Authorizations.Permissions;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Authorizations;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Authorizations;

public class PermissionService : IPermissionService
{
    private readonly IRepository<Permission> permissionRepository;
    private readonly IMapper mapper;
    public PermissionService(IRepository<Permission> permissionRepository, IMapper mapper)
    {
        this.permissionRepository = permissionRepository;
        this.mapper = mapper;
    }

    public async Task<PermissionForResultDto> CreateAsync(PermissionForCreationDto dto)
    {
        var permission = await this.permissionRepository.SelectAll()
            .Where(p => p.Name.ToLower() == dto.Name.ToLower() && p.IsDeleted == true)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (permission is not null)
            throw new GadgetGroveException(409, "Permission is already available");

        var mappedPermission = this.mapper.Map<Permission>(dto);
        mappedPermission.CreatedAt = DateTime.UtcNow;
        var result = await this.permissionRepository.InsertAsync(mappedPermission);

        return this.mapper.Map<PermissionForResultDto>(result);
    }

    public async Task<List<PermissionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var permissions = await permissionRepository.SelectAll()
      .Where(p => p.IsDeleted == false)
      .ToPagedList(@params)
      .ToListAsync();

        return mapper.Map<List<PermissionForResultDto>>(permissions);
    }

    public async Task<PermissionForResultDto> RetrieveByIdAsync(long id)
    {
        var permission = await this.permissionRepository.SelectAll()
            .Where(p => p.Id == id && p.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (permission is null)
            throw new GadgetGroveException(404, "Permission is not available");

        return this.mapper.Map<PermissionForResultDto>(permission);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var result = await this.permissionRepository.SelectAll()
            .Where(rp => rp.Id == id && rp.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (result is null)
            throw new GadgetGroveException(404, "RolePermission is not available");

        await this.permissionRepository.DeleteAsync(id);
        return true;
    }

    public async Task<PermissionForResultDto> ModifyAsync(PermissionForUpdateDto dto)
    {
        var permission = await this.permissionRepository.SelectAll()
            .Where(u => u.Id == dto.Id && u.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (permission is null)
            throw new GadgetGroveException(404, "Permission is not found ");

        var result = this.mapper.Map(dto, permission);
        result.UpdatedAt = DateTime.UtcNow;

        return this.mapper.Map<PermissionForResultDto>(result);
    }
}
