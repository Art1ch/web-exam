using MediatR;

namespace AuthService.Application.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password
) : IRequest<LoginCommandResult>;
