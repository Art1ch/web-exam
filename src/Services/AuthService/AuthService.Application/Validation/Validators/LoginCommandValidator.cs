using AuthService.Application.Commands.Login;

namespace AuthService.Application.Validation.Validators;

public sealed class LoginCommandValidator : ValidatorBase<LoginCommand>
{
    public LoginCommandValidator()
    {
        ValidateEmail(x => x.Email);
        ValidatePassword(x => x.Password);
    }
}
