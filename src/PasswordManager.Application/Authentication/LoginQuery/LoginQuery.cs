using MediatR;

namespace PasswordManager.Application.Authentication.LoginQuery;

public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;