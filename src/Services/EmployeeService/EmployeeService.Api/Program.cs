using EmployeeService.Api.Extensions;
using EmployeeService.Application;
using EmployeeService.Infrastructure;
using Shared.Extensions;

namespace EmployeeService.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var cloudinarySettings = builder.ConfigureCloudinarySettings();
        var appDbSettings = builder.ConfigureAppDbSettings();
        var jwtSettings = builder.ConfigureJwtSettings();

        builder.Services.AddControllersWithViews();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(appDbSettings);
        builder.Services.AddJwtAuthentication(jwtSettings);

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapStaticAssets();
        app.MapControllers();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Employee}/{action=Index}")
            .WithStaticAssets();

        app.Run();
    }
}
