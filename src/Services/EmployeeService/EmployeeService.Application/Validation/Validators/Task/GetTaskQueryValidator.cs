using EmployeeService.Application.Queries.Task.Get;

namespace EmployeeService.Application.Validation.Validators.Task;

public sealed class GetTaskQueryValidator : TaskValidatorBase<GetTaskQuery>
{
    public GetTaskQueryValidator()
    {
        ValidateId(x => x.Id);
    }
}

