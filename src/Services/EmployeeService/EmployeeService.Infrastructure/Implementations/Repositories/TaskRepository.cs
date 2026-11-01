using EmployeeService.Application.Filters;
using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Application.Pagination;
using EmployeeService.Core.Entities;
using EmployeeService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Infrastructure.Implementations.Repositories;

internal sealed class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
{
    private readonly AppDbContext _appDbContext;

    public TaskRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<PaginationResult<TaskEntity>> GetEntitiesAsync(
        TaskFilter taskFilter,
        PaginationParams paginationParams,
        CancellationToken cancellationToken = default
    )
    {
        var query = _appDbContext.Tasks.AsQueryable();

        int? nextCursor = null;

        if (taskFilter.EmployeeId != null)
            query = query.Where(x => x.EmployeeId == taskFilter.EmployeeId);

        if (taskFilter.Name != null)
        {
            var name = taskFilter.Name.Trim().ToLower();
            query = query.Where(x => x.Name.ToLower().Contains(name));
        }

        if (taskFilter.TaskState != null)
            query = query.Where(x => x.TaskState == taskFilter.TaskState);

        if (paginationParams.Cursor.HasValue)
            query = query.Where(x => x.Id > paginationParams.Cursor);

        var entities = await query
            .OrderBy(x => x.Id)
            .Take(paginationParams.PageSize + 1)
            .ToListAsync(cancellationToken);

        if (entities.Count > paginationParams.PageSize)
        {
            nextCursor = entities[^1].Id;

            entities = entities
                .Take(paginationParams.PageSize)
                .ToList();
        }

        return new PaginationResult<TaskEntity>(entities, nextCursor);
    }
}
