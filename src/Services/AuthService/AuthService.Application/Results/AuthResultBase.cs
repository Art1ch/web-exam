namespace AuthService.Application.Results;

public abstract record AuthResultBase(
    bool IsSucceed,
    string? ErrorMessage
);