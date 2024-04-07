using PasswordManager.Domain.Entities;
namespace PasswordManager.Application.Services;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}