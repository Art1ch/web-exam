using EmployeeService.Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Queries.Task.Get;

internal sealed class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, GetTaskQueryResult>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public GetTaskQueryHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<GetTaskQueryResult> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetAsync(request.Id, cancellationToken);

        var result = _mapper.Map<GetTaskQueryResult>(task);

        return result;
    }
}
