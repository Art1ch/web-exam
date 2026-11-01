namespace EmployeeService.Application.Queries.Employee.Get;

public sealed record GetEmployeeQueryResult(
    int Id,
    string Name,
    int Age,
    string Speciality,
    DateOnly EmploymentDate,
    string? AvatarUrl
);