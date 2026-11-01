using EmployeeService.Core.Enums;

namespace EmployeeService.Core.Entities;

public sealed class TaskEntity : EntityBase
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskState TaskState { get; set; }

    public EmployeeEntity Employee { get; set; }
}
