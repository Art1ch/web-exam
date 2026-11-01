using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Core.Entities;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Commands.Task.Create;

internal sealed record CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResult>
{
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;

    public CreateTaskCommandHandler(IMapper mapper, ITaskRepository taskRepository)
    {
        _mapper = mapper;
        _taskRepository = taskRepository;
    }

    public async Task<CreateTaskCommandResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TaskEntity>(request);

        await _taskRepository.CreateAsync(entity, cancellationToken);

        return new CreateTaskCommandResult();
    }
}
