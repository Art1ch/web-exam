using EmployeeService.Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Queries.Employee.Get;

internal sealed class GetEmployeeQueryHander(
    IEmployeeRepository employeeRepository,
    IMapper mapper
) : IRequestHandler<GetEmployeeQuery, GetEmployeeQueryResult>
{
    public async Task<GetEmployeeQueryResult> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetAsync(request.Id, cancellationToken);

        var result = mapper.Map<GetEmployeeQueryResult>(employee);

        return result;
    }
}
