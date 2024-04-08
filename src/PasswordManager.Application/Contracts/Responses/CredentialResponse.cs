namespace PasswordManager.Application.Contracts.Responses;

public record CredentialResponse(
    Guid UserId,
    string Username,
    string Email,
    string Password,
    string WebSite
);