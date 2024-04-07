using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Contracts.Requests.Credential;

public record AddCredentialRequest(
    Guid UserId,
    string Username,
    [EmailAddress]  string Email,
    string Password,
    string WebSite,
    string? CredentialName);