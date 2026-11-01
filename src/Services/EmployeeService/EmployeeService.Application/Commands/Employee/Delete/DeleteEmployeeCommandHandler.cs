using EmployeeService.Application.Interfaces.Repositories;
using MediatR;

namespace EmployeeService.Application.Commands.Employee.Delete;

internal sealed class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, DeleteEmployeeCommandResult>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<DeleteEmployeeCommandResult> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _employeeRepository.DeleteAsync(request.Id, cancellationToken);

        return new DeleteEmployeeCommandResult();
    }
}
