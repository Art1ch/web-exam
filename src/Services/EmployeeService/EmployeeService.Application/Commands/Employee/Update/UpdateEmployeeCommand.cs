using MediatR;
using Microsoft.AspNetCore.Http;

namespace EmployeeService.Application.Commands.Employee.Update;

public sealed record UpdateEmployeeCommand(
    int Id,
    string Name,
    int Age,
    string Speciality,
    DateOnly EmploymentDate,
    string AvatarUrl,
    IFormFile? NewAvatar
) : IRequest<UpdateEmployeeCommandResult>;
