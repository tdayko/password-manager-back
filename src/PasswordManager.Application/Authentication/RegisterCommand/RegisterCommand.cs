using MediatR;

using PasswordManager.Application.Authentication.Contracts;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Authentication.RegisterCommand;

public record RegisterCommand(string Username, [EmailAddress] string Email, string Password)
    : IRequest<AuthenticationResult>;