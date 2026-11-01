using EmployeeService.Application.Validation.Constants.Employee;
using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Api.Models.Employee;

public sealed class EmployeeUpdateViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Employee name is required.")]
    [StringLength(EmployeeValidationConstants.MaxNameLength, MinimumLength = EmployeeValidationConstants.MinNameLength,
        ErrorMessage = "Employee name must be between {2} and {1} characters.")]
    public string Name { get; set; } = string.Empty;

    [Range(EmployeeValidationConstants.MinAge,EmployeeValidationConstants.MaxAge,
        ErrorMessage = "Age must be between {1} and {2}.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Speciality is required.")]
    [StringLength(EmployeeValidationConstants.MaxSpecialityLength, MinimumLength = EmployeeValidationConstants.MinSpecialityLength,
        ErrorMessage = "Speciality must be between {2} and {1} characters.")]
    public string Speciality { get; set; } = string.Empty;

    public DateOnly EmploymentDate { get; set; }

    public string AvatarUrl { get; set; } = string.Empty;

    public IFormFile? NewAvatar { get; set; }
}
