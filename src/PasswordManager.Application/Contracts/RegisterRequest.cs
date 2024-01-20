namespace PasswordManager.Application.Contracts;

public record RegisterRequest(string Username, string Email, string Password);