using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;

namespace EmployeeService.Application.Request.Task;

public sealed record GetTaskEntitiesRequest(
    PaginationParams PaginationParams,
    TaskFilter TaskFilter
);