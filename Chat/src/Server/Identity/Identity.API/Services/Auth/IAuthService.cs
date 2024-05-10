using Identity.API.DataTransferObjects.Auth;

namespace Identity.API.Services.Auth
{
    public interface IAuthService
    {
        Task<TokenDTO> Login(LoginDTO loginDTO);
        Task<TokenDTO> Register(RegisterDTO registerDTO);
        Task<TokenDTO> RefreshTokenAsync(RefreshTokenDTO refreshTokenDTO);
    }
}
