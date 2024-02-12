using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Authentication.Contracts;

public record RegisterRequest
{
    [Required]
    public required string Username { get; set; }
    [EmailAddress]
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}