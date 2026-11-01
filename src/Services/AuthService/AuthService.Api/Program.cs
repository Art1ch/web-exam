using AuthService.Application;
using AuthService.Infrastructure;
using Shared.Extensions;
using EmployeeService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var jwtSettings = builder.ConfigureJwtSettings();
var authDbSettings = builder.ConfigureAuthDbSettings();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(authDbSettings);
builder.Services.AddJwtAuthentication(jwtSettings);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
