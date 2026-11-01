namespace EmployeeService.Api.Models.Employee;

public sealed class EmployeeDeleteViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? AvatarUrl { get; set; }
}
