namespace PasswordManager.Application.Authentication.Contracts;

public record UserResponse(Guid Id, string Username, string Email);
