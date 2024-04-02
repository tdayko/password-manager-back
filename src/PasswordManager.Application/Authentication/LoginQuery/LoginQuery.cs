using MediatR;

using PasswordManager.Application.Authentication.Contracts;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.Authentication.LoginQuery;

public record LoginQuery([EmailAddress] string Email, string Password)
    : IRequest<AuthenticationResult>;