using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;

namespace EmployeeService.Application.Request.Employee;

public sealed record GetEmployeeEntitiesRequest(
    PaginationParams PaginationParams,
    EmployeeFilter EmployeeFilter
);
