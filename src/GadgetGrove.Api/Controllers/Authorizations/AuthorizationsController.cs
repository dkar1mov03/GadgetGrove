using GadgetGrove.Service.DTOs.Logins;
using GadgetGrove.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.Authorizations;

public class AuthorizationsController : BaseController
{
    private readonly IAuthService authService;

    public AuthorizationsController(IAuthService authService)
    {
        this.authService = authService;
    }
    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(LoginDto dto)
    {
        return Ok(await this.authService.AuthenticateAsync(dto.Email, dto.Password));
    }
}
