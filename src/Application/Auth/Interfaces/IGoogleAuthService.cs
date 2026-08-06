using Project.Analytics.Dashboard.Application.Auth.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Analytics.Dashboard.Application.Auth.Interfaces
{
    public interface IGoogleAuthService
    {
        Task<GoogleUserInfoDTO?> ValidateToken(string idToken);
    }
}
