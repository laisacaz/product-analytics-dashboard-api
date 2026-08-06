using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Analytics.Dashboard.Application.Auth.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(
            Guid userId,
            string email);
    }
}
