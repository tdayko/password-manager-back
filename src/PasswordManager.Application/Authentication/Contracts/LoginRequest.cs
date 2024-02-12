using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Authentication.Contracts;

public record LoginRequest
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}