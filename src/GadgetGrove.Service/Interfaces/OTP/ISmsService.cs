using GadgetGrove.Service.DTOs.OTP.Sms;

namespace GadgetGrove.Service.Interfaces.OTP;

public interface ISmsService
{
    public Task<bool> SendAsync(Message message);
}
