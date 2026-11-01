using EmployeeService.Application.Interfaces.Repositories;
using MediatR;

namespace EmployeeService.Application.Commands.Employee.Delete;

internal sealed class DeleteEmployeeCommandHandler(
    IEmployeeRepository employeeRepository    
) : IRequestHandler<DeleteEmployeeCommand, DeleteEmployeeCommandResult>
{
    public async Task<DeleteEmployeeCommandResult> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        await employeeRepository.DeleteAsync(request.Id, cancellationToken);

        return new DeleteEmployeeCommandResult();
    }
}
