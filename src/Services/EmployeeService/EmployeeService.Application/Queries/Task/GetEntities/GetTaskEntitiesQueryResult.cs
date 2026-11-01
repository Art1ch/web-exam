namespace EmployeeService.Application.Queries.Task.GetEntities;

public sealed record GetTaskEntitiesQueryResult(
    List<GetTaskEntitiesQueryResultItem> Items,
    int? NextCursor
);
