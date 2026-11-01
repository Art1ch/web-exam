using EmployeeService.Application.Queries.Task.GetEntities;

namespace EmployeeService.Application.Validation.Validators.Task;

public sealed class GetTaskEntitiesQueryValidator : TaskValidatorBase<GetTaskEntitiesQuery>
{
    public GetTaskEntitiesQueryValidator()
    {
        ValidatePageSize(x => x.PaginationParams.PageSize);
    }
}

