using PasswordManager.Domain.Entities;
namespace PasswordManager.Application.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}