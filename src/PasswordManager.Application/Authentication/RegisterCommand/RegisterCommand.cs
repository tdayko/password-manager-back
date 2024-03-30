using System.ComponentModel.DataAnnotations;

using MediatR;

using PasswordManager.Application.Authentication.Contracts;

namespace PasswordManager.Application.Authentication.RegisterCommand;

public record RegisterCommand(string Username, [EmailAddress] string Email, string Password)
    : IRequest<AuthenticationResult>;