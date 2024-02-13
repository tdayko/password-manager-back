using AutoMapper;
using MediatR;

using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;

namespace PasswordManager.API.Extensions.Endpoints;

public static class AuthenticationEndpoint
{
    public static WebApplication AddAuthenticationEndpoint(this WebApplication app)
    {
        var authEndpoint = app.MapGroup("password-manager/api/auth");

        authEndpoint.MapPost("register", async (RegisterRequest request, ISender sender, IMapper mapper) =>
        {
            AuthenticationResult authResult = await sender.Send(mapper.Map<RegisterCommand>(request));
            return Results.Ok(authResult);
        });

        authEndpoint.MapPost("login", async (LoginRequest request, ISender sender, IMapper mapper) =>
        {
            AuthenticationResult authResult = await sender.Send(mapper.Map<LoginQuery>(request));
            return Results.Ok(authResult);
        });

        return app;
    }
}