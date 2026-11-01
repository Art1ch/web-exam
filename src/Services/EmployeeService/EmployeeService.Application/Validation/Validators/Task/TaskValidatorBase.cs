using EmployeeService.Application.Validation.Constants.Task;
using EmployeeService.Core.Enums;
using FluentValidation;
using System.Linq.Expressions;

namespace EmployeeService.Application.Validation.Validators.Task;

public abstract class TaskValidatorBase<T> : ValidatorBase<T>
{
    protected void ValidateTaskName(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage(TaskValidationMessages.NameRequired)
            .Length(TaskValidationConstants.MinNameLength, TaskValidationConstants.MaxNameLength)
            .WithMessage(TaskValidationMessages.NameLength);
    }

    protected void ValidateDescription(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage(TaskValidationMessages.DescriptionRequired)
            .Length(TaskValidationConstants.MinDescriptionLength, TaskValidationConstants.MaxDescriptionLength)
            .WithMessage(TaskValidationMessages.DescriptionLength);
    }

    protected void ValidateTaskState(Expression<Func<T, TaskState>> expression)
    {
        RuleFor(expression)
            .NotNull()
            .WithMessage(TaskValidationMessages.TaskStateRequired)
            .Must(state => state != TaskState.Unspecified)
            .WithMessage(TaskValidationMessages.TaskStateInvalid);
    }
}