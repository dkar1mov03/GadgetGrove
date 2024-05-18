using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Users;
using GadgetGrove.Service.DTOs.Users;

namespace GadgetGrove.Service.Interfaces.Users;

public interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<User> RetrieveByEmailAsync(string email);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<IEnumerable<UserForResultDto>> RetrieveAllByRoleAsync(PaginationParams @params, long roleId);
}
