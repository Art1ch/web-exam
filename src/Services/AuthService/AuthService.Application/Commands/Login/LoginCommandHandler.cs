using AuthService.Application.Abstractions;
using MapsterMapper;
using MediatR;

namespace AuthService.Application.Commands.Login;

internal sealed class LoginCommandHandler(
    IMapper mapper,
    IAuthService authService
) : IRequestHandler<LoginCommand, LoginCommandResult>
{
    public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var authResult = await authService.LoginAsync(request, cancellationToken);

        var commandResult = mapper.Map<LoginCommandResult>(authResult);

        return commandResult;
    }
}