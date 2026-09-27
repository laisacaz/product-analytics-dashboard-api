using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Analytics.Dashboard.Application.Auth.Interfaces;
using Project.Analytics.Dashboard.Infrastructure.Authentication.Services;
using Project.Analytics.Dashboard.Infrastructure.Authentication.Settings;
using Project.Analytics.Dashboard.Infrastructure.Persistence;
using Project.Analytics.Dashboard.Infrastructure.Persistence.Repositories;

namespace Project.Analytics.Dashboard.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                       .UseSnakeCaseNamingConvention());

            services.Configure<JwtSettings>(
                configuration.GetSection("Jwt"));

            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGoogleAuthService, GoogleAuthService>();

            return services;
        }
    }
}