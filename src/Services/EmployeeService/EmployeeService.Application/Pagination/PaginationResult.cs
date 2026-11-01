namespace EmployeeService.Application.Pagination;

public sealed record PaginationResult<TEntity>(
    List<TEntity> Entities,
    int? NextCursor
);