using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Persistence.Authentication.Contracts;

public class RegisterRequest(string username, string email, string password)
{
    [Required]
    [Description("The username of the user")]
    public string Username { get; init; } = username;

    [EmailAddress]
    [Required]
    [Description("The email of the user")]
    public string Email { get; init; } = email;

    [Required]
    [Description("The password of the user")]
    public string Password { get; init; } = password;
}