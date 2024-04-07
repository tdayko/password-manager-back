namespace PasswordManager.Application.Contracts.Requests;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

public class RegisterRequest(string username, string email, string password)
{
    public string Username { get; set; } = username;
    [EmailAddress]
    public string Email { get; set; } = email;
    [PasswordPropertyText]
    public string Password { get; set; } = password;
}