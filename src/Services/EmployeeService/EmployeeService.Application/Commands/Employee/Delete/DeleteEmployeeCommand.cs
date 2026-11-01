using MediatR;

namespace EmployeeService.Application.Commands.Employee.Delete;

public sealed record DeleteEmployeeCommand(
    int Id
) : IRequest<DeleteEmployeeCommandResult>;
