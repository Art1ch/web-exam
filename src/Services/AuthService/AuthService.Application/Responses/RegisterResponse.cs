namespace AuthService.Application.Responses;

public sealed record RegisterResponse(
    bool IsSucceed,
    string? ErrorMessage
) : AuthResponseBase(IsSucceed, ErrorMessage);