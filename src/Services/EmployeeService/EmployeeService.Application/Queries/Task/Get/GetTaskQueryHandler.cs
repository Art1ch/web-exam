using EmployeeService.Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Queries.Task.Get;

internal sealed class GetTaskQueryHandler(
    ITaskRepository taskRepository,
    IMapper mapper
) : IRequestHandler<GetTaskQuery, GetTaskQueryResult>
{
    public async Task<GetTaskQueryResult> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        var task = await taskRepository.GetAsync(request.Id, cancellationToken);

        var result = mapper.Map<GetTaskQueryResult>(task);

        return result;
    }
}
