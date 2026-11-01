using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Infrastructure.Context;
using EmployeeService.Infrastructure.Implementations.Repositories;
using EmployeeService.Infrastructure.Implementations.Services;
using EmployeeService.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Infrastructure;

public static class Injection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, AppDbSettings appDbsettings)
    {

        services
            .AddAppDbContext(appDbsettings)
            .AddRepositories()
            .AddServices();

        return services;
    }

    private static IServiceCollection AddAppDbContext(this IServiceCollection services, AppDbSettings settings) =>
        services.AddDbContext<AppDbContext>(x => x.UseNpgsql(settings.ConnectionString));

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAvatarService, CloudinaryAvatarService>();

        return services;
    }
}
