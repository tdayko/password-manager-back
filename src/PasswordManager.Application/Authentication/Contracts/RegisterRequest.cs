using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Authentication.Contracts;

public record RegisterRequest
{
    [Required]
    [Description("The username of the user")]
    public required string Username { get; set; }

    [EmailAddress]
    [Required]
    [Description("The email of the user")]
    public required string Email { get; set; }

    [Required]
    [Description("The password of the user")]
    public required string Password { get; set; }
}