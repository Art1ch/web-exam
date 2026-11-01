using EmployeeService.Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Queries.Employee.GetEntities;

internal sealed class GetEmployeeEntitiesQueryHandler(
    IEmployeeRepository employeeRepository,
    IMapper mapper
) : IRequestHandler<GetEmployeeEntitiesQuery, GetEmployeeEntitiesQueryResult>
{
    public async Task<GetEmployeeEntitiesQueryResult> Handle(GetEmployeeEntitiesQuery request, CancellationToken cancellationToken)
    {
        var repositoryResult = await employeeRepository.GetEntitiesAsync(
            request.EmployeeFilter,
            request.PaginationParams,
            cancellationToken
        );

        var queryResult = mapper.Map<GetEmployeeEntitiesQueryResult>(repositoryResult);

        return queryResult;
    }
}
