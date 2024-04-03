using MediatR;
using PasswordManager.Application.Persistence.Authentication.Contracts;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Persistence.Authentication.RegisterCommand;

public record RegisterCommand(string Username, [EmailAddress] string Email, string Password)
    : IRequest<AuthenticationResult>;