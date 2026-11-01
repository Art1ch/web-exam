using EmployeeService.Core.Enums;

namespace EmployeeService.Application.Responses.Task;

public sealed record GetTaskResponse(
    int Id,
    string Name,
    string Description,
    TaskState TaskState
);
