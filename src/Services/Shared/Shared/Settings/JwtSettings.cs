namespace Shared.Settings;

public sealed class JwtSettings
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiresAtMinutes { get; set; }
}
