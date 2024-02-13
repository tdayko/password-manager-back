using MediatR;
using PasswordManager.Application.Authentication.Contracts;

namespace PasswordManager.Application.Authentication.RegisterCommand;

public record RegisterCommand : IRequest<AuthenticationResult>
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}