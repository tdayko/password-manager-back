using PasswordManager.Application.Contracts;

namespace PasswordManager.Application.Authentication.Contracts;

public record AuthenticationResult(UserResponse User, string Token);
