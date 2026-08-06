using Microsoft.Extensions.DependencyInjection;
using Project.Analytics.Dashboard.Application.Auth.Interfaces;
using Project.Analytics.Dashboard.Infrastructure.Authentication.Services;

namespace Project.Analytics.Dashboard.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IGoogleAuthService, IGoogleAuthService>();

            return services;
        }
    }
}