using AuthService.Application.Abstractions;
using AuthService.Application.Commands.Login;
using AuthService.Application.Commands.Register;
using AuthService.Application.Results;
using AuthService.Application.Validation.Constants;
using AuthService.Core.Entities;
using AuthService.Infrastructure.Context;
using AuthService.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Implementations;

internal sealed class AccountAuthService : IAuthService
{
    private readonly AuthDbContext _context;
    private readonly PasswordHasherHelper _passwordHasher;
    private readonly JwtTokenGeneratorHelper _jwtTokenGenerator;

    public AccountAuthService(
        AuthDbContext context,
        PasswordHasherHelper passwordHasher,
        JwtTokenGeneratorHelper jwtTokenGenerator
    )
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResult> LoginAsync(LoginCommand command, CancellationToken cancellationToken = default)
    {
        var account = await _context.Accounts
            .Where(x => x.Email == command.Email)
            .FirstOrDefaultAsync(cancellationToken);

        if (account == null)
            return new LoginResult(false, CommonValidationMessages.InvalidCredentials, null);

        var isValidPassword = _passwordHasher.VerifyPassword(command.Password, account.PasswordHash);

        if (!isValidPassword)
            return new LoginResult(false, CommonValidationMessages.InvalidCredentials, null);

        var token = _jwtTokenGenerator.GenerateJwtToken(account);

        return new LoginResult(true, null, token);
    }

    public async Task<RegisterResult> RegisterAsync(RegisterCommand command, CancellationToken cancellationToken = default)
    {
        var isAccountExists = await _context.Accounts.AnyAsync(x => x.Email == command.Email, cancellationToken);

        if (isAccountExists)
            return new RegisterResult(false, CommonValidationMessages.AccountAlreadyExists);

        var passwordHash = _passwordHasher.GeneratePasswordHash(command.Password);

        var account = new AccountEntity
        {
            Name = command.Name,
            Email = command.Email,
            PasswordHash = passwordHash,
        };

        await _context.Accounts.AddAsync(account, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);  

        return new RegisterResult(true, null);
    }
}
