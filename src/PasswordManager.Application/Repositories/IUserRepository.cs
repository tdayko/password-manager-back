using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Repositories;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    User? GetUserByUserId(Guid userId);
    void AddUser(User user);
}