using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Core.Entities;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Commands.Task.Update;

internal sealed class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskCommandResult>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public UpdateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<UpdateTaskCommandResult> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TaskEntity>(request);

        await _taskRepository.UpdateAsync(entity, cancellationToken);

        return new UpdateTaskCommandResult();
    }
}
