namespace EmployeeService.Application.Validation.Constants.Employee;

public static class EmployeeValidationMessages
{
    public const string NameRequired = "Employee name is required.";
    public static readonly string NameLength =
        $"Employee name must be between {EmployeeValidationConstants.MinNameLength} and {EmployeeValidationConstants.MaxNameLength} characters.";

    public static readonly string AgeRange =
        $"Age must be between {EmployeeValidationConstants.MinAge} and {EmployeeValidationConstants.MaxAge}.";
        
    public const string SpecialityRequired = "Speciality is required.";
    public static readonly string SpecialityLength =
        $"Speciality must be between {EmployeeValidationConstants.MinSpecialityLength} and {EmployeeValidationConstants.MaxSpecialityLength} characters.";
        
    public const string EmploymentDateRequired = "Employment date is required.";
    public const string EmploymentDateNotInFuture = "Employment date cannot be in the future.";

    public const string AvatarInvalidType = "Avatar must be an image (jpg, jpeg, png, webp).";
    public static readonly string AvatarTooLarge =
        $"Avatar size must not exceed {EmployeeValidationConstants.MaxAvatarSize} bytes.";
}
