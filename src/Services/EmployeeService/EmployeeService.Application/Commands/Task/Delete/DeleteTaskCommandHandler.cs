using EmployeeService.Application.Interfaces.Repositories;
using MediatR;

namespace EmployeeService.Application.Commands.Task.Delete;

internal sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, DeleteTaskCommandResult>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<DeleteTaskCommandResult> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await _taskRepository.DeleteAsync(request.Id, cancellationToken);

        return new DeleteTaskCommandResult();
    }
}
