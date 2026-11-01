using AuthService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Context;

internal sealed class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<AccountEntity> Accounts { get; set; }
}
