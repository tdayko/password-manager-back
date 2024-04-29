using System.Collections.ObjectModel;

namespace PasswordManager.Domain.Entities;

public class User(string userName, string password, string email)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string UserName { get; private set; } = userName.Trim();
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public List<Credential> Credentials { get; private set; } = [];

    private void AddCredential(Credential credential)
    {
        Credentials.Add(credential);
    }

    private void UpdateUser(string? username, string? passwordHash, string email)
    {
        UserName = username ?? UserName;
        Password = passwordHash ?? Password;
        Email = email;
    }
}