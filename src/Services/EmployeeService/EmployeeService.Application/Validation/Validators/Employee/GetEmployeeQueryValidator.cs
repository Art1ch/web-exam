using EmployeeService.Application.Queries.Employee.Get;

namespace EmployeeService.Application.Validation.Validators.Employee;

public sealed class GetEmployeeQueryValidator : EmployeeValidatorBase<GetEmployeeQuery>
{
    public GetEmployeeQueryValidator()
    {
        ValidateId(x => x.Id);
    }
}
