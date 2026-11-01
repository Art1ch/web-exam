using EmployeeService.Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Queries.Task.GetEntities;

internal sealed class GetTaskEntitiesQueryHandler : IRequestHandler<GetTaskEntitiesQuery, GetTaskEntitiesQueryResult>
{
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;

    public GetTaskEntitiesQueryHandler(IMapper mapper, ITaskRepository taskRepository)
    {
        _mapper = mapper;
        _taskRepository = taskRepository;
    }

    public async Task<GetTaskEntitiesQueryResult> Handle(GetTaskEntitiesQuery request, CancellationToken cancellationToken)
    {
        var repositoryResult = await _taskRepository.GetEntitiesAsync(request.TaskFilter, request.PaginationParams, cancellationToken);

        var queryResult = _mapper.Map<GetTaskEntitiesQueryResult>(repositoryResult);

        return queryResult;
    }
}
