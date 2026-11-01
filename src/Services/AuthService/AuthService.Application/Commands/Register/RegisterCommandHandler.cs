using AuthService.Application.Abstractions;
using MapsterMapper;
using MediatR;

namespace AuthService.Application.Commands.Register;

internal sealed class RegisterCommandHandler(
    IMapper mapper,
    IAuthService authService
) : IRequestHandler<RegisterCommand, RegisterCommandResult>
{
    public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var authResult = await authService.RegisterAsync(request, cancellationToken);

        var commandResult = mapper.Map<RegisterCommandResult>(authResult);

        return commandResult;
    }
}
