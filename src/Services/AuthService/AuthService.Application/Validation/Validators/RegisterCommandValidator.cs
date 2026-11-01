using AuthService.Application.Commands.Register;

namespace AuthService.Application.Validation.Validators;

public sealed class RegisterCommandValidator : ValidatorBase<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        ValidateEmail(x => x.Email);
        ValidateName(x => x.Name);
        ValidatePassword(x => x.Password);
    }
}
