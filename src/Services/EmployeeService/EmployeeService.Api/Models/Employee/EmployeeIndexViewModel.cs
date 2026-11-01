using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;
using EmployeeService.Application.Queries.Employee.GetEntities;

namespace EmployeeService.Api.Models.Employee;

public sealed class EmployeeIndexViewModel
{
    public List<GetEmployeeEntitiesQueryResultItem> Items { get; set; } = new();
    public EmployeeFilter Filter { get; set; } = new(null, null, null, null, null, null);
    public PaginationParams Pagination { get; set; } = new(null);
    public int? NextCursor { get; set; }
}
