namespace PasswordManager.Application.Contracts.Responses;

public record UserResponse(Guid Id, string Username, string Email);