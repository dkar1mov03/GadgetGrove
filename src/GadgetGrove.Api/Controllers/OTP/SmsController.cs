using GadgetGrove.Api.Helpers;
using GadgetGrove.Service.DTOs.OTP.Sms;
using GadgetGrove.Service.Interfaces.OTP;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.OTP;

public class SmsController : BaseController
{
    private readonly ISmsService _smsService;

    public SmsController(ISmsService smsService)
    {
        _smsService = smsService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Message message)
    {
        var response = new Response
        {
            Message = "Success",
            StatusCode = 200,
            Data = await this._smsService.SendAsync(message),
        };
        return Ok(response);
    }
}
