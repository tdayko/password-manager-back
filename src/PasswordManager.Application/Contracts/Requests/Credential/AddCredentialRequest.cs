using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Contracts.Requests.Credential;

public class AddCredentialRequest(string username, string email, string password, Uri webSite)
{
    public string Username { get; private set; } = username;
    [EmailAddress] public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    [Url] public Uri WebSite { get; private set; } = webSite;
}