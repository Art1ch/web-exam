namespace AuthService.Application.Commands.Login;

public sealed record LoginCommandResult(
    bool IsSucceed,
    string? ErrorMessage,
    string? AccessToken
);
