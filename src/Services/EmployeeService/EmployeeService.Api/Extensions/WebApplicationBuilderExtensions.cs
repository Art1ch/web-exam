using EmployeeService.Infrastructure.Settings;
using Shared.Settings;

namespace EmployeeService.Api.Extensions;

internal static class WebApplicationBuilderExtensions
{
    internal static CloudinarySettings ConfigureCloudinarySettings(this WebApplicationBuilder builder) =>
        builder.ConfigureSettings<CloudinarySettings>();

    internal static AppDbSettings ConfigureAppDbSettings(this WebApplicationBuilder builder) =>
        builder.ConfigureSettings<AppDbSettings>();

    internal static JwtSettings ConfigureJwtSettings(this WebApplicationBuilder builder) =>
        builder.ConfigureSettings<JwtSettings>();

    private static T ConfigureSettings<T>(this WebApplicationBuilder builder) where T : class
    {
        var sectionName = typeof(T).Name;
        var settings = builder.Configuration.GetSection(sectionName).Get<T>()!;
        builder.Services.Configure<T>(builder.Configuration.GetSection(sectionName));
        return settings;
    }
}