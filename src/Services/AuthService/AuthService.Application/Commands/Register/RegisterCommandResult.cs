namespace AuthService.Application.Commands.Register;

public sealed record RegisterCommandResult(
    bool IsSucceed,
    string? ErrorMessage
);
