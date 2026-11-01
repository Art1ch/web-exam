namespace AuthService.Application.Results;

public sealed record LoginResult(
    bool IsSucceed,
    string? ErrorMessage,
    string? AccessToken
) : AuthResultBase(IsSucceed, ErrorMessage);