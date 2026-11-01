using Microsoft.AspNetCore.Http;

namespace EmployeeService.Application.Request.Employee;

public sealed record UpdateEmployeeRequest(
    string Name,
    int Age,
    string Speciality,
    DateOnly EmploymentDate,
    string AvatarUrl,
    IFormFile? NewAvatar
);
