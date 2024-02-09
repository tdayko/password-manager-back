using PasswordManager.Domain.Entities;
namespace PasswordManager.Application.Authentication.Contracts;

public record AuthenticationResult(User User, string Token);