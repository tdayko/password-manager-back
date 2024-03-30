using System.ComponentModel.DataAnnotations;

using MediatR;

using PasswordManager.Application.Authentication.Contracts;

namespace PasswordManager.Application.Authentication.LoginQuery;

public record LoginQuery([EmailAddress] string Email, string Password)
    : IRequest<AuthenticationResult>;