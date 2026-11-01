using AuthService.Application.Validation.Constants;
using FluentValidation;
using System.Linq.Expressions;

namespace AuthService.Application.Validation.Validators;

public abstract class ValidatorBase<T> : AbstractValidator<T>
{
    protected void ValidateName(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotNull()
            .WithMessage(CommonValidationMessages.NameRequired)
            .NotEmpty()
            .WithMessage(CommonValidationMessages.NameRequired)
            .Length(CommonValidationConstants.MinNameLength, CommonValidationConstants.MaxNameLength)
            .WithMessage(CommonValidationMessages.NameLength);
    }

    protected void ValidatePassword(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotNull()
            .WithMessage(CommonValidationMessages.PasswordRequired)
            .NotEmpty()
            .WithMessage(CommonValidationMessages.PasswordRequired)
            .Length(CommonValidationConstants.MinPasswordLength, CommonValidationConstants.MaxPasswordLength)
            .WithMessage(CommonValidationMessages.PasswordLength)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$")
            .WithMessage(CommonValidationMessages.PasswordTooWeak);
    }

    protected void ValidateEmail(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotNull()
            .WithMessage(CommonValidationMessages.EmailRequired)
            .NotEmpty()
            .WithMessage(CommonValidationMessages.EmailRequired)
            .EmailAddress()
            .WithMessage(CommonValidationMessages.EmailInvalid);
    }
}
