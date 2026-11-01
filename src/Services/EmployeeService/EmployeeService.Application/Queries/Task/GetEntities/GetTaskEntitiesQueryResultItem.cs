using EmployeeService.Core.Enums;

namespace EmployeeService.Application.Queries.Task.GetEntities;

public sealed record GetTaskEntitiesQueryResultItem(
    int Id,
    int EmployeeId,
    string Name,
    string Description,
    TaskState TaskState
);