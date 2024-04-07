using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Contracts.Requests.Credential;

public record AddCredentialRequest(
    string Username,
    [EmailAddress] string Email,
    string Password,
    [Url] Uri WebSite,
    string? CredentialName);