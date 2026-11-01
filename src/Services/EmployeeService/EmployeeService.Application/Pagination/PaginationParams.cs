namespace EmployeeService.Application.Pagination;

public sealed record PaginationParams(
    int? Cursor,
    int PageSize = 25
);