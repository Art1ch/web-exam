using EmployeeService.Application.Queries.Employee.GetEntities;

namespace EmployeeService.Application.Responses.Employee;

public sealed record GetEmployeeEntitiesResponse(
    List<GetEmployeeEntitiesQueryResultItem> Items,
    int? Cursor
);
