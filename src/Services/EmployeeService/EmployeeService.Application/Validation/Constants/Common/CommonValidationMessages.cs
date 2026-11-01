namespace EmployeeService.Application.Validation.Constants.Common;

public static class CommonValidationMessages
{
    public static readonly string IdRequired = "Id is required.";

    public static readonly string PageSizeRange =
        $"Page size must be between {CommonValidationConstants.MinPageSize} and {CommonValidationConstants.MaxPageSize}.";
}
