using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Application.Contracts;
using PasswordManager.Application.Errors;

namespace PasswordManager.API.EndPoints;

public static class AuthenticationEndpoint
{
    public static IEndpointRouteBuilder  AddAuthenticationEndpoint(this IEndpointRouteBuilder app)
    {
        var authEndpoint = app.MapGroup("password-manager/api/");

        authEndpoint.MapPost("register", async (RegisterRequest request, ISender sender, IMapper mapper) =>
        {
            AuthenticationResult authResult = await sender.Send(mapper.Map<RegisterCommand>(request));
            return Results.Ok(mapper.Map<StandardSuccessResponse<UserResponse>>(authResult));
        })
        .WithName("Register")
        .Produces<StandardSuccessResponse<UserResponse>>(StatusCodes.Status200OK)
        .WithOpenApi(x => {
            x.Summary = "Register to the Password Manager API";
            x.Description = "Register to the Password Manager API with your credentials";
            return x;
        });

        authEndpoint.MapPost("login", async (LoginRequest request, ISender sender, IMapper mapper) =>
        {
            AuthenticationResult authResult = await sender.Send(mapper.Map<LoginQuery>(request));
            return Results.Ok(mapper.Map<StandardSuccessResponse<UserResponse>>(authResult));
        })
        .WithName("Login")
        .Produces<StandardSuccessResponse<UserResponse>>(StatusCodes.Status200OK)
        .WithOpenApi(x => {
            x.Summary = "Login to the Password Manager API";
            x.Description = "Login to the Password Manager API with your credentials";
            return x;
        });

        return app;
    }
}