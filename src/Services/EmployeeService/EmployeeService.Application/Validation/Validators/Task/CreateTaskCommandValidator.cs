using EmployeeService.Application.Commands.Task.Create;

namespace EmployeeService.Application.Validation.Validators.Task;

public sealed class CreateTaskCommandValidator : TaskValidatorBase<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        ValidateTaskName(x => x.Name);
        ValidateDescription(x => x.Description);
        ValidateTaskState(x => x.TaskState);
    }
}
