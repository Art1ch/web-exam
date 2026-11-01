using EmployeeService.Core.Enums;

namespace EmployeeService.Application.Request.Task;

public sealed record CreateTaskRequest(
    int EmployeeId,
    string Name,
    string Description,
    TaskState TaskState
);
