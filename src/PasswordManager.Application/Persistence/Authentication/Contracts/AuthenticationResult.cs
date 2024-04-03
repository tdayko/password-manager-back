using PasswordManager.Application.Contracts;
namespace PasswordManager.Application.Persistence.Authentication.Contracts;

public record AuthenticationResult(UserResponse User, string Token);