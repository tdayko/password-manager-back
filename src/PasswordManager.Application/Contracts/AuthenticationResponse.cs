namespace PasswordManager.Application.Contracts;

public record AuthenticationResponse(Guid Id, string Username, string Email, string Token);