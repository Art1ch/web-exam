using EmployeeService.Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Queries.Task.GetEntities;

internal sealed class GetTaskEntitiesQueryHandler(
    ITaskRepository taskRepository,
    IMapper mapper
) : IRequestHandler<GetTaskEntitiesQuery, GetTaskEntitiesQueryResult>
{
    public async Task<GetTaskEntitiesQueryResult> Handle(GetTaskEntitiesQuery request, CancellationToken cancellationToken)
    {
        var repositoryResult = await taskRepository.GetEntitiesAsync(
            request.TaskFilter,
            request.PaginationParams,
            cancellationToken
        );

        var queryResult = mapper.Map<GetTaskEntitiesQueryResult>(repositoryResult);

        return queryResult;
    }
}
