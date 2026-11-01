using EmployeeService.Application.Validation.Constants.Task;
using EmployeeService.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Api.Models.Task;

public sealed class TaskCreateViewModel
{
    [Range(1, int.MaxValue, ErrorMessage = "Employee is required.")]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Task name is required.")]
    [StringLength(TaskValidationConstants.MaxNameLength, MinimumLength = TaskValidationConstants.MinNameLength,
        ErrorMessage = "Task name must be between {2} and {1} characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(TaskValidationConstants.MaxDescriptionLength, MinimumLength = TaskValidationConstants.MinDescriptionLength,
        ErrorMessage = "Description must be between {2} and {1} characters.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Task state is required.")]
    [EnumDataType(typeof(TaskState), ErrorMessage = "Task state is invalid.")]
    public TaskState TaskState { get; set; }
}