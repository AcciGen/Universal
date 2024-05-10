using Identity.API.DataTransferObjects.Auth;
using Identity.API.Models;

namespace Identity.API.Services.Token
{
    public interface ITokenService
    {
        public string GenerateJWT(User user);
        public ValueTask<TokenDTO> RefreshToken(RefreshTokenDTO refreshTokenDTO);
    }
}
