namespace PasswordManager.Application.Contracts.Responses;
using PasswordManager.Application.Contracts;

public record AuthenticationResponse(UserResponse User, string Token);