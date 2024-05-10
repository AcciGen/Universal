using Identity.API.DataTransferObjects.Auth;
using Identity.API.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
            => _authService = authService;

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
            => Ok(await _authService.Login(loginDTO));

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
            => Ok(await _authService.Register(registerDTO));

        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenDTO refreshTokenDTO)
            => Ok(await _authService.RefreshTokenAsync(refreshTokenDTO));
    }
}
