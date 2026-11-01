using EmployeeService.Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Queries.Employee.Get;

internal sealed class GetEmployeeQueryHander : IRequestHandler<GetEmployeeQuery, GetEmployeeQueryResult>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public GetEmployeeQueryHander(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<GetEmployeeQueryResult> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetAsync(request.Id, cancellationToken);

        var result = _mapper.Map<GetEmployeeQueryResult>(employee);

        return result;
    }
}
