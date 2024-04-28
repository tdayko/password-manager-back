using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Infra.Repositories;

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

    public User? GetUserByUserId(Guid userId)
    {
        return Users.SingleOrDefault(x => x.Id == userId);
    }
}