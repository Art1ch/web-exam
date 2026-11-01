using EmployeeService.Application.Validation.Constants.Employee;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace EmployeeService.Application.Validation.Validators.Employee;

public abstract class EmployeeValidatorBase<T> : ValidatorBase<T>
{
    protected void ValidateEmployeeName(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage(EmployeeValidationMessages.NameRequired)
            .Length(EmployeeValidationConstants.MinNameLength, EmployeeValidationConstants.MaxNameLength)
            .WithMessage(EmployeeValidationMessages.NameLength);
    }

    protected void ValidateAge(Expression<Func<T, int>> expression)
    {
        RuleFor(expression)
            .InclusiveBetween(EmployeeValidationConstants.MinAge, EmployeeValidationConstants.MaxAge)
            .WithMessage(EmployeeValidationMessages.AgeRange);
    }

    protected void ValidateSpeciality(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage(EmployeeValidationMessages.SpecialityRequired)
            .Length(EmployeeValidationConstants.MinSpecialityLength, EmployeeValidationConstants.MaxSpecialityLength)
            .WithMessage(EmployeeValidationMessages.SpecialityLength);
    }

    protected void ValidateEmploymentDate(Expression<Func<T, DateOnly>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage(EmployeeValidationMessages.EmploymentDateRequired)
            .Must(date => date <= DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage(EmployeeValidationMessages.EmploymentDateNotInFuture);
    }

    protected void ValidateAvatarFormFile(Expression<Func<T, IFormFile>> expression)
    {
        RuleFor(expression)
            .Must(file => file is null || file.Length <= EmployeeValidationConstants.MaxAvatarSize)
            .WithMessage(EmployeeValidationMessages.AvatarTooLarge);
    }
}
