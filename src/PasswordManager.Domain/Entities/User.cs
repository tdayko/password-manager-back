using System.Text.RegularExpressions;

namespace PasswordManager.Domain.Entities;

partial class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime LastModified { get; private set; }
    public User(string name, string email, string passwordHash, DateTime created)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Titulo invalido");
        if (string.IsNullOrEmpty(email) && ValidateEmail().IsMatch(email)) throw new ArgumentException("Email invalido");
        if (string.IsNullOrEmpty(passwordHash)) throw new ArgumentException("Senha invalido");

        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Created = DateTime.UtcNow;
        LastModified = DateTime.UtcNow;
    }

    [GeneratedRegex("^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
    private static partial Regex ValidateEmail();
}