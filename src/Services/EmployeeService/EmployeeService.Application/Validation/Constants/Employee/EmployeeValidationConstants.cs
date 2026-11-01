namespace EmployeeService.Application.Validation.Constants.Employee;

public static class EmployeeValidationConstants
{
    public const int MinNameLength = 2;
    public const int MaxNameLength = 100;

    public const int MinAge = 16;
    public const int MaxAge = 100;

    public const int MinSpecialityLength = 2;
    public const int MaxSpecialityLength = 100;

    public const int MaxAvatarSize = 10 * 1024 * 1024; // 10 MB
}
