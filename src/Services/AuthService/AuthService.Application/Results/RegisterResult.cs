namespace AuthService.Application.Results;

public sealed record RegisterResult(
    bool IsSucceed,
    string? ErrorMessage
) : AuthResultBase(IsSucceed, ErrorMessage);
