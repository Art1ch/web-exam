namespace AuthService.Application.Validation.Constants;

public static class CommonValidationMessages
{
    public const string NameRequired = "Name is required.";
    public static readonly string NameLength =
        $"Name must be between {CommonValidationConstants.MinNameLength} and {CommonValidationConstants.MaxNameLength} characters.";

    public const string EmailRequired = "Email is required.";
    public const string EmailInvalid = "Email format is invalid.";

    public const string PasswordRequired = "Password is required.";
    public static readonly string PasswordLength =
         $"Name must be between {CommonValidationConstants.MinPasswordLength} and {CommonValidationConstants.MaxPasswordLength} characters.";
    public static readonly string PasswordTooWeak = "Password must contain special symbols";

    public const string InvalidCredentials = "Invalid email or password.";
    public const string AccountAlreadyExists = "An account with this email already exists.";
}