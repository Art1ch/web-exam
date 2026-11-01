namespace AuthService.Application.Responses;

public sealed record LoginResponse(
    bool IsSucceed,
    string? ErrorMessage,
    string? AccessToken
) : AuthResponseBase(IsSucceed, ErrorMessage);
