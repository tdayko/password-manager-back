using PasswordManager.Domain.Entities;
namespace PasswordManager.Application.Repositories;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}