using EmployeeService.Application.Commands.Employee.Delete;

namespace EmployeeService.Application.Validation.Validators.Employee;

public sealed class DeleteEmployeeCommandValidator : EmployeeValidatorBase<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        ValidateId(x => x.Id);
    }
}
