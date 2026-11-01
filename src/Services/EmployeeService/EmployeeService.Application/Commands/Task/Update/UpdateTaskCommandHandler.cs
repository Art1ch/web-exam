using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Core.Entities;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Commands.Task.Update;

internal sealed class UpdateTaskCommandHandler(
    ITaskRepository taskRepository,
    IMapper mapper
) : IRequestHandler<UpdateTaskCommand, UpdateTaskCommandResult>
{
    public async Task<UpdateTaskCommandResult> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<TaskEntity>(request);

        await taskRepository.UpdateAsync(entity, cancellationToken);

        return new UpdateTaskCommandResult();
    }
}
