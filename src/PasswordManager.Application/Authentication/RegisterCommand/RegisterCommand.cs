using MediatR;
namespace PasswordManager.Application.Authentication.RegisterCommand;

public record RegisterCommand(string Username, string Email, string Password) : IRequest<AuthenticationResult>;