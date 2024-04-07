using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Contracts.Requests.Authentication;

public class RegisterRequest(string username, string email, string password)
{
    public string Username { get; set; } = username;

    [EmailAddress] public string Email { get; set; } = email;

    [PasswordPropertyText] public string Password { get; set; } = password;
}