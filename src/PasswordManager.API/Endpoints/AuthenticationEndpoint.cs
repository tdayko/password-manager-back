using AutoMapper;
using MediatR;

using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Application.Contracts;

namespace PasswordManager.API.Endpoints;

public static class AuthenticationEndpoint
{
    public static IEndpointRouteBuilder AddAuthenticationEndpoint(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder authEndpoint = app.MapGroup("password-manager/api/");

        // register
        authEndpoint.MapPost("register", async (RegisterRequest request, ISender sender, IMapper mapper) 
            => await HandleRegister(request, sender, mapper)
        )
        .WithName("Register")
        .Produces<StandardSuccessResponse<AuthenticationResult>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Register to the Password Manager API";
            x.Description = "Register to the Password Manager API with your credentials";
            return x;
        });

        // login
        authEndpoint.MapPost("login", async (LoginRequest request, ISender sender, IMapper mapper) 
            => await HandleLogin(request, sender, mapper)
        )
        .WithName("Login")
        .Produces<StandardSuccessResponse<AuthenticationResult>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Login to the Password Manager API";
            x.Description = "Login to the Password Manager API with your credentials";
            return x;
        });

        return app;
    }

    public static async Task<IResult> HandleRegister(RegisterRequest request,ISender sender,IMapper mapper)
    {
        AuthenticationResult authResult = await sender.Send(mapper.Map<RegisterCommand>(request));
        return Results.Ok(mapper.Map<StandardSuccessResponse<AuthenticationResult>>(authResult));
    }

    public static async Task<IResult> HandleLogin(LoginRequest request, ISender sender, IMapper mapper)
    {
        AuthenticationResult authResult = await sender.Send(mapper.Map<LoginQuery>(request));
        return Results.Ok(mapper.Map<StandardSuccessResponse<AuthenticationResult>>(authResult));
    }
}