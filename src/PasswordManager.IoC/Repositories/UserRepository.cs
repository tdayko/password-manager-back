using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.IoC.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = [];

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(x => x.Email == email);
    }
}