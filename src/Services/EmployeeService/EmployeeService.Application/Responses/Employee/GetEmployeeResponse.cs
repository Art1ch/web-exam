namespace EmployeeService.Application.Responses.Employee;

public sealed record GetEmployeeResponse(
    int Id,
    string Name,
    int Age,
    string Speciality,
    DateOnly EmploymentDate,
    string? AvatarUrl
);
