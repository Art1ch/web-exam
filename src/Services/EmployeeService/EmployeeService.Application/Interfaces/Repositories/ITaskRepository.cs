using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;
using EmployeeService.Core.Entities;

namespace EmployeeService.Application.Interfaces.Repositories;

public interface ITaskRepository : IRepository<TaskEntity>
{
    Task<PaginationResult<TaskEntity>> GetEntitiesAsync(
        TaskFilter taskFilter,
        PaginationParams paginationParams,
        CancellationToken cancellationToken = default
    );
}