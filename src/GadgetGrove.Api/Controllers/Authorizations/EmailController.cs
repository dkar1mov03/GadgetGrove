﻿using GadgetGrove.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.Authorizations;

public class EmailController : BaseController
{
    private readonly IEmailService emailService;
    public EmailController(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    /// <summary>
    /// Send email
    /// </summary>
    /// <param name="to"></param>
    /// <param name="subject"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    [HttpPost]
    public async ValueTask<ActionResult> EmailAsync([FromForm] string to, [FromForm] string subject, [FromForm] string message)
    {
        await emailService.SendEmailAsync(to, subject, message);
        return Ok();
    }
}
