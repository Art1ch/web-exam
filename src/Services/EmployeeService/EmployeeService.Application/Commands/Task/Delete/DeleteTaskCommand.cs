using MediatR;

namespace EmployeeService.Application.Commands.Task.Delete;

public sealed record DeleteTaskCommand(
    int Id
) : IRequest<DeleteTaskCommandResult>;
