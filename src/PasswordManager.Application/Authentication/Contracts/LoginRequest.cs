using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Authentication.Contracts;

public class LoginRequest(string email, string password)
{
    [Required]
    [EmailAddress]
    [Description("The email of the user")]
    public string Email { get; set; } = email;

    [Required]
    [Description("The password of the user")]
    public string Password { get; set; } = password;
}