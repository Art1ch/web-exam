namespace AuthService.Application.Responses;

public abstract record AuthResponseBase(
    bool IsSucceed,
    string? ErrorMessage
);
