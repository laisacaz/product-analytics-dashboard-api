using Project.Analytics.Dashboard.Application.Auth.DTOs;
using Project.Analytics.Dashboard.Application.Auth.Interfaces;

namespace Project.Analytics.Dashboard.Application.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGoogleAuthService _googleAuthService;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(
        IGoogleAuthService googleAuthService,
        IJwtTokenService jwtTokenService)
        {
            _googleAuthService = googleAuthService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponseDTO> LoginWithGoogle(
            GoogleLoginRequestDTO request)
        {
            var googleUser =
                await _googleAuthService.ValidateToken(request.TokenId);


            if (googleUser == null)
            {
                throw new Exception("Invalid Google token");
            }

            var userId = Guid.NewGuid();
            var accessToken = _jwtTokenService.GenerateToken(userId, googleUser.Email);

            return new LoginResponseDTO
            {
                AccessToken = accessToken,

                User = new UserAuthDTO
                {
                    Id = userId,
                    Name = googleUser.Name,
                    Email = googleUser.Email,
                    ProfileImage = googleUser.ProfileImage
                }
            };
        }
    }
}
