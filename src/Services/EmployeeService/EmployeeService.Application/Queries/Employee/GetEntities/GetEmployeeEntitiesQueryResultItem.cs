namespace EmployeeService.Application.Queries.Employee.GetEntities;

public sealed record GetEmployeeEntitiesQueryResultItem(
    int Id,
    string Name,
    int Age,
    string Speciality,
    DateOnly EmploymentDate,
    string? AvatarUrl
);