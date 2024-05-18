using GadgetGrove.Service.DTOs.Logins;

namespace GadgetGrove.Service.Interfaces.Users;

public interface IAuthService
{
    Task<LoginResultDto> AuthenticateAsync(string email, string password);
}