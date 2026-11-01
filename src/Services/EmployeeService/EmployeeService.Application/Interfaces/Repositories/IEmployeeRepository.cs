using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;
using EmployeeService.Core.Entities;

namespace EmployeeService.Application.Interfaces.Repositories;

public interface IEmployeeRepository : IRepository<EmployeeEntity>
{
    Task<PaginationResult<EmployeeEntity>> GetEntitiesAsync(
        EmployeeFilter employeeFilter,
        PaginationParams paginationParams,
        CancellationToken cancellationToken = default
    );
}
