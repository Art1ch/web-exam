namespace EmployeeService.Core.Entities;

public sealed class EmployeeEntity : EntityBase
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Speciality { get; set; }
    public DateOnly EmploymentDate { get; set; }
    public string? AvatarUrl { get; set; }

    public ICollection<TaskEntity> Tasks { get; set; }
}