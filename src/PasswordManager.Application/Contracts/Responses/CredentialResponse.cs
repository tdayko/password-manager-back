using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Contracts.Responses;

public class CredentialResponse(Guid id, Guid userId, string username, string email, string password, string webSite)
{
    public Guid Id { get; private set; } = id;
    public string Username { get; private set; } = username;
    [EmailAddress] public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    [Url] public string WebSite { get; private set; } = webSite;
    public Guid UserId { get; private set; } = userId;
}