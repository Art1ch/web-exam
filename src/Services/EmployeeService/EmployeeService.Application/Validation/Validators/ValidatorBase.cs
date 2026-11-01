using EmployeeService.Application.Validation.Constants.Common;
using FluentValidation;
using System.Linq.Expressions;

namespace EmployeeService.Application.Validation.Validators;

public abstract class ValidatorBase<T> : AbstractValidator<T>
{
    protected void ValidatePageSize(Expression<Func<T, int>> expression)
    {
        RuleFor(expression)
            .InclusiveBetween(CommonValidationConstants.MinPageSize, CommonValidationConstants.MaxPageSize)
            .WithErrorCode(CommonValidationMessages.PageSizeRange);
    }

    protected void ValidateId(Expression<Func<T, int>> expression)
    {
        RuleFor(expression)
            .GreaterThan(0)
            .WithMessage(CommonValidationMessages.IdRequired);
    }
}
