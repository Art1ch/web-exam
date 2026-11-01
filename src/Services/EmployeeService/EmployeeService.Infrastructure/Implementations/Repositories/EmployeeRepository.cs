using EmployeeService.Application.Filters;
using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Application.Pagination;
using EmployeeService.Core.Entities;
using EmployeeService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Infrastructure.Implementations.Repositories;

internal sealed class EmployeeRepository : RepositoryBase<EmployeeEntity>, IEmployeeRepository
{
    private readonly AppDbContext _appDbContext;

    public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<PaginationResult<EmployeeEntity>> GetEntitiesAsync(
        EmployeeFilter employeeFilter,
        PaginationParams paginationParams,
        CancellationToken cancellationToken = default
    )
    {
        var query = _appDbContext.Employees.AsQueryable();

        int? nextCursor = null;

        if (!string.IsNullOrEmpty(employeeFilter.Name))
        {
            var name = employeeFilter.Name.Trim().ToLower();
            query = query.Where(x => x.Name.ToLower().Contains(name));
        }

        if (employeeFilter.FromAge != null)
            query = query.Where(x => x.Age >= employeeFilter.FromAge);

        if (employeeFilter.ToAge != null)
            query = query.Where(x => x.Age <= employeeFilter.ToAge);

        if (!string.IsNullOrEmpty(employeeFilter.Speciality))
        {
            var speciality = employeeFilter.Speciality.Trim().ToLower();
            query = query.Where(x => x.Speciality.ToLower().Contains(speciality));
        }

        if (employeeFilter.FromEmploymentDate != null)
            query = query.Where(x => x.EmploymentDate >= employeeFilter.FromEmploymentDate);

        if (employeeFilter.ToEmploymentDate != null)
            query = query.Where(x => x.EmploymentDate <= employeeFilter.ToEmploymentDate);

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

        return new PaginationResult<EmployeeEntity>(entities, nextCursor);
    }
}
