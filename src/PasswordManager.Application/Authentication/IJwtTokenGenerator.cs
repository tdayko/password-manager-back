using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}