using GadgetGrove.Service.DTOs.Registrations.UserRegistrations;
using GadgetGrove.Service.DTOs.Registrations;

namespace GadgetGrove.Service.Interfaces.Registrations;

public interface IUserRegistrationService
{
    Task<bool> VerifyCodeAsync(CodeVerification dto);
    Task<string> SendVerificationCodeAsync(SendVerification dto);
    Task<UserRegistrationForResultDto> AddAsync(UserRegistrationForCreationDto dto);
}
