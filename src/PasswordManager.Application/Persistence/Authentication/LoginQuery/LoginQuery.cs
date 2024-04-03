using MediatR;
using PasswordManager.Application.Persistence.Authentication.Contracts;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Persistence.Authentication.LoginQuery;

public record LoginQuery([EmailAddress] string Email, string Password)
    : IRequest<AuthenticationResult>;