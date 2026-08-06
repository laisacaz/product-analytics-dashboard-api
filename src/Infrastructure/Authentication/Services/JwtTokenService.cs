using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project.Analytics.Dashboard.Application.Auth.Interfaces;
using Project.Analytics.Dashboard.Infrastructure.Authentication.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.Analytics.Dashboard.Infrastructure.Authentication.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtTokenService(IOptions<JwtSettings> options)
        {
            var settings = options.Value;

            _secret = settings.Secret
                ?? throw new InvalidOperationException("Jwt:Secret not configured.");

            _issuer = settings.Issuer
                ?? throw new InvalidOperationException("Jwt:Issuer not configured.");

            _audience = settings.Audience
                ?? throw new InvalidOperationException("Jwt:Audience not configured.");
        }

        public string GenerateToken(Guid userId, string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_secret));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}