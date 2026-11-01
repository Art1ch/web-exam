using MediatR;

namespace AuthService.Application.Commands.Register;

public sealed record RegisterCommand(
    string Name,
    string Email,
    string Password
) : IRequest<RegisterCommandResult>;
