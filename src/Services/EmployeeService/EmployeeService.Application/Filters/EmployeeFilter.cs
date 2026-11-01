namespace EmployeeService.Application.Filters;

public sealed record EmployeeFilter(
    string? Name,
    int? FromAge,
    int? ToAge,
    string? Speciality,
    DateOnly? FromEmploymentDate,
    DateOnly? ToEmploymentDate
);
