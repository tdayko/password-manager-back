using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Persistence;

public interface IUserRepository
{
    User? GetUserbyEmail(string email);
    void AddUser(User user);
}