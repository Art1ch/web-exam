using EmployeeService.Application.Commands.Task.Update;

namespace EmployeeService.Application.Validation.Validators.Task;

public sealed class UpdateTaskCommandValidator : TaskValidatorBase<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        ValidateId(x => x.Id);
        ValidateTaskName(x => x.Name);
        ValidateDescription(x => x.Description);
        ValidateTaskState(x => x.TaskState);
    }
}

