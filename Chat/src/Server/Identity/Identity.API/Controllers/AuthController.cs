using Identity.API.DataTransferObjects.Auth;
using Identity.API.Services.Auth;
using Microsoft.AspNetCore.Authorization;
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
            => Ok(await _authService.LoginAsync(loginDTO));

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
           => Ok(await _authService.ProfileAsync());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
            => Ok(await _authService.RegisterAsync(registerDTO));

        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenDTO refreshTokenDTO)
            => Ok(await _authService.RefreshTokenAsync(refreshTokenDTO));
    }
}
