using EmployeeService.Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Queries.Employee.GetEntities;

internal sealed class GetEmployeeEntitiesQueryHandler : IRequestHandler<GetEmployeeEntitiesQuery, GetEmployeeEntitiesQueryResult>
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeEntitiesQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task<GetEmployeeEntitiesQueryResult> Handle(GetEmployeeEntitiesQuery request, CancellationToken cancellationToken)
    {
        var repositoryResult = await _employeeRepository.GetEntitiesAsync(request.EmployeeFilter, request.PaginationParams, cancellationToken);

        var queryResult = _mapper.Map<GetEmployeeEntitiesQueryResult>(repositoryResult);

        return queryResult;
    }
}
