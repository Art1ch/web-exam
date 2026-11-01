using EmployeeService.Core.Enums;
using MediatR;

namespace EmployeeService.Application.Commands.Task.Update;

public sealed record UpdateTaskCommand(
    int Id,
    string Name,
    string Description,
    TaskState TaskState
) : IRequest<UpdateTaskCommandResult>;
