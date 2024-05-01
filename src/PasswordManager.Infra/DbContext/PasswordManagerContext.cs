using Microsoft.EntityFrameworkCore;

using PasswordManager.Domain.Entities;

namespace PasswordManager.Infra.DbContext;

public class PasswordManagerContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Credential>? Credentials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "PasswordManagerDb");

    }
}