using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserByUserId(Guid userId);
    Task AddUser(User user);
}