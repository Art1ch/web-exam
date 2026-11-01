namespace EmployeeService.Application.Validation.Constants.Task;

public static class TaskValidationMessages
{
    public const string NameRequired = "Task name is required.";
    public static readonly string NameLength =
            $"Task name must be between {TaskValidationConstants.MinNameLength} and {TaskValidationConstants.MaxNameLength} characters.";

    public const string DescriptionRequired = "Description is required.";
    public static readonly string DescriptionLength =
            $"Description must be between {TaskValidationConstants.MinDescriptionLength} and {TaskValidationConstants.MaxDescriptionLength} characters.";
        
    public const string TaskStateRequired = "Task state is required.";
    public const string TaskStateInvalid = "Task state is invalid.";
}