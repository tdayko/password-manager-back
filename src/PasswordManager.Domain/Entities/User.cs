using System.Collections.ObjectModel;
namespace PasswordManager.Domain.Entities;

public class User(string username, string passwordHash)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Username { get; private set; } = username.Trim();
    public string PasswordHash { get; private set; } = passwordHash;

    public Collection<Credential> Credentials { get; private set; } = [];

    private void UpdateUser(string? username, string? passwordHash)
    {
        Username = username ?? Username;
        PasswordHash = passwordHash ?? PasswordHash;
    }
}
