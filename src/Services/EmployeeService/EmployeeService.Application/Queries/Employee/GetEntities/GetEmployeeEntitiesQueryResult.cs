namespace EmployeeService.Application.Queries.Employee.GetEntities;

public sealed record GetEmployeeEntitiesQueryResult(
    List<GetEmployeeEntitiesQueryResultItem> Items,
    int? NextCursor
);
