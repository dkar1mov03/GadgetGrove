﻿using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Users;
using GadgetGrove.Service.DTOs.Users;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IRepository<User> userRepository;

    public UserService(IRepository<User> userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Adds new User to database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    /// <exception cref="CustomException"></exception>    
    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await userRepository.SelectAll()
            .Where(u => u.Email == dto.Email)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is not null)
            throw new GadgetGroveException(404, "User already exists");

        var mapped = mapper.Map<User>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        await userRepository.InsertAsync(mapped);

        return mapper.Map<UserForResultDto>(mapped);
    }

    /// <summary>
    /// Modifies an existing user in the database based on the provided user ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be modified.</param>
    /// <param name="dto">The data transfer object containing the updated user information.</param>
    /// <returns>A task representing the modified user's information in the form of UserForResultDto.</returns>
    /// <exception cref="CustomException">Thrown if the user with the specified ID is not found (HTTP 404 Not Found).</exception>
    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await userRepository.SelectAll()
           .Where(u => u.Id == id)
           .AsNoTracking()
           .FirstOrDefaultAsync();

        if (user is null)
            throw new GadgetGroveException(404, "User not found");

        var mapped = mapper.Map(dto, user);
        mapped.UpdatedAt = DateTime.UtcNow;
        await userRepository.UpdateAsync(mapped);

        return mapper.Map<UserForResultDto>(mapped);
    }

    /// <summary>
    /// Removes an existing user from the database based on the provided user ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be removed.</param>
    /// <returns>A task representing the success of the removal operation (true if successful).</returns>
    /// <exception cref="CustomException">Thrown if the user with the specified ID is not found (HTTP 404 Not Found).</exception>
    public async Task<bool> RemoveAsync(long id)
    {
        var user = await userRepository.SelectAll()
            .Where(u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new GadgetGroveException(404, "User not found");

        await userRepository.DeleteAsync(id);
        return true;
    }
    /// <summary>
    /// Retrieves all user from database with pagination by role
    /// </summary>
    /// <param name="params"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public async Task<IEnumerable<UserForResultDto>> RetrieveAllByRoleAsync(PaginationParams @params, long roleId)
    {
        var users = await userRepository.SelectAll()
            .Where(u => u.RolId == roleId && !u.IsDeleted)
            .ToPagedList(@params)
            .ToListAsync();

        return mapper.Map<IEnumerable<UserForResultDto>>(users);
    }
    /// <summary>
    /// Retrieves a paginated list of all users from the database based on the specified pagination parameters.
    /// </summary>
    /// <param name="@params">Pagination parameters such as page number and page size.</param>
    /// <returns>
    /// A task representing the collection of users retrieved in the form of UserForResultDto.
    /// </returns>
    /// <exception cref="CustomException">Thrown if no users are found based on the pagination parameters (HTTP 404 Not Found).</exception>
    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await userRepository.SelectAll()
            .ToPagedList(@params)
             .AsNoTracking()
             .ToListAsync();
        if (users is null)
            throw new GadgetGroveException(404, "User is not found!");

        return mapper.Map<IEnumerable<UserForResultDto>>(users);
    }
    /// <summary>
    /// Retrieve user by email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<User> RetrieveByEmailAsync(string email)
     => await userRepository.SelectAll().Where(u => u.Email == email).AsNoTracking().FirstOrDefaultAsync();
    /// <summary>
    /// Retrieves a user from the database based on the provided user ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be retrieved.</param>
    /// <returns>
    /// A task representing the retrieved user information in the form of UserForResultDto.
    /// </returns>
    /// <exception cref="CustomException">Thrown if the user with the specified ID is not found (HTTP 404 Not Found).</exception>
    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await userRepository.SelectAll()
               .Where(u => u.Id == id)
               .AsNoTracking()
               .FirstOrDefaultAsync();

        if (user is null)
            throw new GadgetGroveException(404, "User is not found!");

        return mapper.Map<UserForResultDto>(user);
    }
}