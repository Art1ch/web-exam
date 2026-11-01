using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;
using MediatR;

namespace EmployeeService.Application.Queries.Task.GetEntities;

public sealed record GetTaskEntitiesQuery(
    TaskFilter TaskFilter,
    PaginationParams PaginationParams
) : IRequest<GetTaskEntitiesQueryResult>;
