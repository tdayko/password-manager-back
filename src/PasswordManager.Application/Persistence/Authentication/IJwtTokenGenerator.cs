using PasswordManager.Domain.Entities;
namespace PasswordManager.Application.Persistence.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}