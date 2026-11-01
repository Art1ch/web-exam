using Microsoft.AspNetCore.Http;

namespace EmployeeService.Application.Request.Employee;

public sealed record CreateEmployeeRequest(
    string Name,
    int Age,
    string Speciality,
    DateOnly EmploymentDate,
    IFormFile? Avatar
);
