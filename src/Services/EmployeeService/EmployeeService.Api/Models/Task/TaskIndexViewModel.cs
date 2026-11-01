using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;
using EmployeeService.Application.Queries.Task.GetEntities;

namespace EmployeeService.Api.Models.Task;

public sealed class TaskIndexViewModel
{
    public List<GetTaskEntitiesQueryResultItem> Items { get; set; } = new();
    public TaskFilter Filter { get; set; } = new(null, null, null);
    public PaginationParams Pagination { get; set; } = new(null);
    public int? NextCursor { get; set; }
}
