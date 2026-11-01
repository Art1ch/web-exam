using BCrypt.Net;

namespace AuthService.Infrastructure.Helpers;

internal sealed class PasswordHasherHelper
{
    private const int _workFactor = 12;
    private const HashType _hashType = HashType.SHA384;

    public string GeneratePasswordHash(string password)
    {
        var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, _workFactor, _hashType);
        return passwordHash;
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        var isVerified = BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash, _hashType);
        return isVerified;
    }
}
