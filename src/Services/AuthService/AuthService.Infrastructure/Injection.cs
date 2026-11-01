using AuthService.Application.Abstractions;
using AuthService.Infrastructure.Context;
using AuthService.Infrastructure.Helpers;
using AuthService.Infrastructure.Implementations;
using AuthService.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure;

public static class Injection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, AuthDbSettings authDbSettings)
    {
        return services
            .AddAuthDbContext(authDbSettings)
            .AddHelpers()
            .AddServices();
    }

    private static IServiceCollection AddAuthDbContext(this IServiceCollection services, AuthDbSettings authDbSettings) =>
        services.AddDbContext<AuthDbContext>(x => x.UseNpgsql(authDbSettings.ConnectionString));

    private static IServiceCollection AddHelpers(this IServiceCollection services)
    {
        return services
            .AddScoped<PasswordHasherHelper>()
            .AddScoped<JwtTokenGeneratorHelper>();
    }

    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddScoped<IAuthService, AccountAuthService>();
}
