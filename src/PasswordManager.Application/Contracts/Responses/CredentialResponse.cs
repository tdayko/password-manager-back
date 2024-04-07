namespace PasswordManager.Application.Contracts;

public record Credential(
    Guid UserId,
    string Username,
    string Email,
    string PasswordHash,
    string WebSite,
    string? CredentialName
);