using Microsoft.IdentityModel.Tokens;
using Project.Analytics.Dashboard.Application.Auth.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.Analytics.Dashboard.Infrastructure.Authentication.Services
{
    public class JwtTokenService : IJwtTokenService

    {
        private readonly string _secret;

        public JwtTokenService(string secret)
        {
            _secret = secret;
        }

        public string GenerateToken(
            Guid userId,
            string email)
        {
            var claims = new[]
            {
            new Claim(
                JwtRegisteredClaimNames.Sub,
                userId.ToString()),

            new Claim(
                JwtRegisteredClaimNames.Email,
                email)
        };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_secret));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
