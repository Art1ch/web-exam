using EmployeeService.Application.Interfaces.Repositories;
using MediatR;

namespace EmployeeService.Application.Commands.Task.Delete;

internal sealed class DeleteTaskCommandHandler(
    ITaskRepository taskRepository    
) : IRequestHandler<DeleteTaskCommand, DeleteTaskCommandResult>
{
    public async Task<DeleteTaskCommandResult> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await taskRepository.DeleteAsync(request.Id, cancellationToken);

        return new DeleteTaskCommandResult();
    }
}
