using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Core.Entities;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Commands.Task.Create;

internal sealed record CreateTaskCommandHandler(
    IMapper mapper,
    ITaskRepository taskRepository
) : IRequestHandler<CreateTaskCommand, CreateTaskCommandResult>
{
    public async Task<CreateTaskCommandResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<TaskEntity>(request);

        await taskRepository.CreateAsync(entity, cancellationToken);

        return new CreateTaskCommandResult();
    }
}
