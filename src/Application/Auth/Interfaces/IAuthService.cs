using Project.Analytics.Dashboard.Application.Auth.DTOs;

namespace Project.Analytics.Dashboard.Application.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginWithGoogle(GoogleLoginRequestDTO request);
    }
}
