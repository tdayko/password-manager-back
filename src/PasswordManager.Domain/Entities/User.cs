using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Common;

namespace PasswordManager.Domain.Entities;

partial class User : BaseEntity
{
    public IList<Credential> Credentials { get; private set; }

    public User(string email, string passwordHash, string name) : base(email, passwordHash, name)
        => Credentials = new List<Credential>();
}