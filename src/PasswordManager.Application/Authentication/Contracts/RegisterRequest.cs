using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Authentication.Contracts;

public class RegisterRequest(string username, string email, string password)
{
    [Required]
    public string Username { get; init; } = username;

    [EmailAddress]
    [Required]
    [Description("The email of the user")]
    public string Email { get; init; } = email;

    [Required]
    [Description("The password of the user")]
    public string Password { get; init; } = password;
}