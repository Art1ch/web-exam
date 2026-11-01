using MediatR;

namespace EmployeeService.Application.Queries.Task.Get;

public sealed record GetTaskQuery(
    int Id
) : IRequest<GetTaskQueryResult>;
