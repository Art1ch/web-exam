using AuthService.Application.Commands.Login;
using AuthService.Application.Commands.Register;
using AuthService.Application.Results;

namespace AuthService.Application.Abstractions;

public interface IAuthService
{
    Task<RegisterResult> RegisterAsync(RegisterCommand command, CancellationToken cancellationToken = default);
    Task<LoginResult> LoginAsync(LoginCommand command, CancellationToken cancellationToken = default);
}
