using EmployeeService.Core.Enums;

namespace EmployeeService.Application.Queries.Task.Get;

public sealed record GetTaskQueryResult(
    int Id,
    string Name,
    string Description,
    TaskState TaskState
);