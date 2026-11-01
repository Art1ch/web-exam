using EmployeeService.Core.Enums;

namespace EmployeeService.Application.Filters;

public sealed record TaskFilter(
    int? EmployeeId,
    string? Name,
    TaskState? TaskState
);