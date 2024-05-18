using GadgetGrove.Service.Interfaces.OTP;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.OTP;

public class SendSmsToUserController : BaseController
{
    private readonly ISendSmsToUserService _sendSmsToUserService;

    public SendSmsToUserController(ISendSmsToUserService sendSmsToGraduatedUserService)
    {
        _sendSmsToUserService = sendSmsToGraduatedUserService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync()
    {
        var result = await this._sendSmsToUserService.SendSmsToAllUsersAsync();
        return Ok(result);
    }
}
