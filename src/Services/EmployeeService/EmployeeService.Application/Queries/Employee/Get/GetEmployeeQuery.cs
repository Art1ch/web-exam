using MediatR;

namespace EmployeeService.Application.Queries.Employee.Get;

public sealed record GetEmployeeQuery(
    int Id
) : IRequest<GetEmployeeQueryResult>;
