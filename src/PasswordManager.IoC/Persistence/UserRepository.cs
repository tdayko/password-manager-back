using PasswordManager.Application.Persistence;
using PasswordManager.Domain.Entities;

namespace PasswordManager.IoC.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(x => x.Email == email);
    }
}
