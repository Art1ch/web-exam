using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;
using MediatR;

namespace EmployeeService.Application.Queries.Employee.GetEntities;

public sealed record GetEmployeeEntitiesQuery(
    PaginationParams PaginationParams,
    EmployeeFilter EmployeeFilter
) : IRequest<GetEmployeeEntitiesQueryResult>;
