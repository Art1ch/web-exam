using EmployeeService.Application.Commands.Task.Delete;

namespace EmployeeService.Application.Validation.Validators.Task;

public sealed class DeleteTaskCommandValidator : TaskValidatorBase<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        ValidateId(x => x.Id);
    }
}

