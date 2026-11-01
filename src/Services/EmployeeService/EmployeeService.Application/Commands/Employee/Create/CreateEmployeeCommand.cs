using MediatR;
using Microsoft.AspNetCore.Http;

namespace EmployeeService.Application.Commands.Employee.Create;

public sealed record CreateEmployeeCommand(
    string Name,
    int Age,
    string Speciality,
    DateOnly EmploymentDate,
    IFormFile? Avatar
) : IRequest<CreateEmployeeCommandResult>;
