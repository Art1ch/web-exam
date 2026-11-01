using EmployeeService.Application.Queries.Task.GetEntities;

namespace EmployeeService.Application.Responses.Task;

public sealed record GetTaskEntitiesResponse(
    List<GetTaskEntitiesQueryResultItem> Items,
    int? Cursor
);