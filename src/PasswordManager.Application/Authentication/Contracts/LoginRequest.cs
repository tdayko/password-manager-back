namespace PasswordManager.Application.Authentication.Contracts;

public record LoginRequest(string Email, string Password);