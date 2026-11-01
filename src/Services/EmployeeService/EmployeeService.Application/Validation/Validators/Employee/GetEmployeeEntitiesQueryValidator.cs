using EmployeeService.Application.Queries.Employee.GetEntities;

namespace EmployeeService.Application.Validation.Validators.Employee;

public sealed class GetEmployeeEntitiesQueryValidator : EmployeeValidatorBase<GetEmployeeEntitiesQuery>
{
    public GetEmployeeEntitiesQueryValidator()
    {
        ValidatePageSize(x => x.PaginationParams.PageSize);
    }
}
