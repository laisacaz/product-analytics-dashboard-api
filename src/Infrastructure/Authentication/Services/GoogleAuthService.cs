using Google.Apis.Auth;
using Project.Analytics.Dashboard.Application.Auth.DTOs;
using Project.Analytics.Dashboard.Application.Auth.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Analytics.Dashboard.Infrastructure.Authentication.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        public async Task<GoogleUserInfoDTO?> ValidateToken(string tokenId)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(
                    tokenId);

                return new GoogleUserInfoDTO
                {
                    GoogleId = payload.Subject,
                    Name = payload.Name,
                    Email = payload.Email,
                    ProfileImage = payload.Picture
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
