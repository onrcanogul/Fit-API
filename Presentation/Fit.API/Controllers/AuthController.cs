using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs.Auth;
using Fit.Application.DTOs.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            TokenDto token = await _authService.Login(request);
            return Ok(token);
        }
        [HttpPost("refresh-token-login")]
        public async Task<IActionResult> RefreshTokenLogin(string refreshToken)
        {
            TokenDto token = await _authService.RefreshTokenLogin(refreshToken);
            return Ok(token);
        }
    }
}
