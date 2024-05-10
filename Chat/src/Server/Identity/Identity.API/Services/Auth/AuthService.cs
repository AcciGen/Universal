using Identity.API.Data;
using Identity.API.DataTransferObjects.Auth;
using Identity.API.Models;
using Identity.API.Services.Helper;
using Identity.API.Services.Token;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _jwtTokenService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(ApplicationDbContext context, ITokenService jwtTokenService, IPasswordHasher passwordHasher)
        {
            _context = context;
            _jwtTokenService = jwtTokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<TokenDTO> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.PhoneNumber == loginDTO.PhoneNumber);

            if (user == null)
                throw new Exception("Chiqmadi");

            if (!_passwordHasher.Verify(user.PasswordHash, loginDTO.Password, user.Salt))
                throw new Exception("Username or password is not valid");

            return new TokenDTO(
                AccessToken: _jwtTokenService.GenerateJWT(user),
                RefreshToken: user.RefreshToken,
                ExpireDate: user.RefreshTokenExpireDate ?? DateTime.Now.AddMinutes(1440)
            );
        }

        public async Task<TokenDTO> Register(RegisterDTO registerDTO)
        {
            var salt = Guid.NewGuid().ToString();
            var PasswordHash = _passwordHasher.Encrypt(registerDTO.Password, salt);

            var user = new User
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Username = registerDTO.UserName,
                PhoneNumber = registerDTO.PhoneNumber,

                Salt = salt,
                PasswordHash = PasswordHash,
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpireDate = DateTime.Now.AddMinutes(2)
            };

            var entityEntry = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new TokenDTO(
                AccessToken: _jwtTokenService.GenerateJWT(entityEntry.Entity),
                RefreshToken: user.RefreshToken,
                ExpireDate: user.RefreshTokenExpireDate ?? DateTime.Now.AddMinutes(1440)
            );
        }

        public async Task<TokenDTO> RefreshTokenAsync(RefreshTokenDTO refreshTokenDTO)
        {
            TokenDTO token = await _jwtTokenService.RefreshToken(refreshTokenDTO);

            return token;
        }
    }
}
