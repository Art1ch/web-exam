using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using EmployeeService.Application.PipelineBehaviors;

namespace EmployeeService.Application;

public static class Injection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddMapping()
            .AddMediator()
            .AddValidators()
            .AddPipelineBehaviors();
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        return services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }

    private static IServiceCollection AddValidators(this IServiceCollection services) =>
       services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Scoped);

    private static IServiceCollection AddPipelineBehaviors(this IServiceCollection services) =>
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    private static IServiceCollection AddMapping(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        services.AddMapster();
        
        return services;
    }
}
