using EmployeeService.Core.Enums;
using MediatR;

namespace EmployeeService.Application.Commands.Task.Create;

public sealed record CreateTaskCommand(
    int EmployeeId,
    string Name,
    string Description,
    TaskState TaskState
) : IRequest<CreateTaskCommandResult>;
