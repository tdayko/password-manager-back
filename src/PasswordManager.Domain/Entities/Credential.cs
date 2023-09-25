using PasswordManager.Domain.Common;
namespace PasswordManager.Domain.Entities;

public class Credential : BaseEntity
{
    public string Uri { get; private set; }

    public Credential(string email, string passwordHash, string name, string uri) : base(email, passwordHash, name)
        => Uri = uri;
    
}