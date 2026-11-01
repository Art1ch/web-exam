using EmployeeService.Core.Enums;

namespace EmployeeService.Application.Request.Task;

public sealed record UpdateTaskRequest(
    string Name,
    string Description,
    TaskState TaskState
);