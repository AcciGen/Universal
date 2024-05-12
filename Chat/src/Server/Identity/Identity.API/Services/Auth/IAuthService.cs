using Identity.API.DataTransferObjects.Auth;

namespace Identity.API.Services.Auth
{
    public interface IAuthService
    {
        ValueTask<TokenDTO> LoginAsync(LoginDTO loginDTO);
        ValueTask<TokenDTO> RegisterAsync(RegisterDTO registerDTO);
        ValueTask<TokenDTO> RefreshTokenAsync(RefreshTokenDTO refreshTokenDTO);
        ValueTask<ProfileInfoDTO> ProfileAsync();
    }
}
