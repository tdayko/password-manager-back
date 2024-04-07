namespace PasswordManager.Application.Contracts;

public record Credential(
    Guid UserId,
    string Username,
    string Email,
    string Password,
    string WebSite,
    string? CredentialName
);