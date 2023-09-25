using System.Text.RegularExpressions;
namespace PasswordManager.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime LastModifiedDate { get; private set; }

    public BaseEntity(string email, string passwordHash, string name)
    {
        if (string.IsNullOrEmpty(email) && ValidateEmail(email)) throw new ArgumentException("Email invalido");
        if (string.IsNullOrEmpty(passwordHash)) throw new ArgumentException("Senha invalido");
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Titulo invalido");
        
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        CreatedDate = DateTime.UtcNow;
    }

    private static bool ValidateEmail(string email)
    {
        Regex regex = new ("^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
        return regex.IsMatch(email);
    }
}

