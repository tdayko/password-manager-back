namespace PasswordManager.Application.Contracts.Authentication;

public record AuthenticationResponse(Guid Id, string Username, string Email, string Token);