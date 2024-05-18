namespace GadgetGrove.Service.Interfaces.OTP;

public interface ISendSmsToUserService
{
    public Task<bool> SendSmsToAllUsersAsync();
}
