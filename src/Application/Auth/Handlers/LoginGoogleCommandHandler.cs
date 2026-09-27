using MediatR;
using Project.Analytics.Dashboard.Application.Auth.Commands;
using Project.Analytics.Dashboard.Application.Auth.DTOs;
using Project.Analytics.Dashboard.Application.Auth.Interfaces;
using Project.Analytics.Dashboard.Domain.Entities;
using Project.Analytics.Dashboard.Domain.Entities.User;

namespace Project.Analytics.Dashboard.Application.Auth.Handlers;

public class LoginGoogleCommandHandler
    : IRequestHandler<LoginGoogleCommand, string>
{
    private readonly IGoogleAuthService _googleAuthService;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IUserRepository _userRepository;

    public LoginGoogleCommandHandler(
        IGoogleAuthService googleAuthService,
        IJwtTokenService jwtTokenService,
        IUserRepository userRepository)
    {
        _googleAuthService = googleAuthService;
        _jwtTokenService = jwtTokenService;
        _userRepository = userRepository;
    }

    public async Task<string> Handle(
        LoginGoogleCommand request,
        CancellationToken cancellationToken)
    {
        GoogleUserInfoDTO googleUser =
            await _googleAuthService.ValidateToken(request.Token);

        User? user =
            await _userRepository.GetByGoogleIdAsync(
                googleUser.GoogleId,
                cancellationToken);

        if (user is null)
        {
            user = new User(
                googleUser.GoogleId,
                googleUser.Name,
                googleUser.Email,
                googleUser.ProfileImage);

            await _userRepository.InsertAsync(
                user,
                cancellationToken);
        }

        string token = _jwtTokenService.GenerateToken(
            user.Id,
            user.Email);

        return token;
    }
}