namespace PasswordManager.Application.Contracts;

public record RegisterRequest
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
};