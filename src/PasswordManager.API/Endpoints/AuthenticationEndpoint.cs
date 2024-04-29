using AutoMapper;
using PasswordManager.Application.Contracts.Requests.Authentication;
using PasswordManager.Application.Contracts.Responses;
using PasswordManager.Application.Errors;
using PasswordManager.Application.Repositories;
using PasswordManager.Application.Services;
using PasswordManager.Domain.Entities;

namespace PasswordManager.API.Endpoints;

public static class AuthenticationEndpoint
{
    public static IEndpointRouteBuilder AddAuthenticationEndpoint(this IEndpointRouteBuilder app)
    {
        var authEndpoint = app.MapGroup("password-manager/api/auth")
            .AllowAnonymous()
            .WithTags("Authentication");

        // register
        authEndpoint.MapPost("register", HandleRegister)
            .WithName("Register")
            .Produces<StandardSuccessResponse<AuthenticationResponse>>()
            .WithOpenApi(x =>
            {
                x.Summary = "Register new user";
                return x;
            });

        // login
        authEndpoint.MapPost("login",HandleLogin)
            .WithName("Login")
            .Produces<StandardSuccessResponse<AuthenticationResponse>>()
            .WithOpenApi(x =>
            {
                x.Summary = "Login user";
                return x;
            });

        return app;
    }
    
    #region private methods
    private static async Task<IResult> HandleRegister(RegisterRequest request, IUserRepository userRepository,
        IJwtTokenService jwtTokenService, IMapper mapper)
    {
        if (await userRepository.GetUserByEmail(request.Email) != null) throw new DuplicateEmailException();

        request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = mapper.Map<User>(request);
        jwtTokenService.GenerateToken(user);

        var authResponse = new AuthenticationResponse(
            mapper.Map<UserResponse>(user),
            jwtTokenService.GenerateToken(user)
        );

        await userRepository.AddUser(user);
        return Results.Ok(new StandardSuccessResponse<AuthenticationResponse>(authResponse));
    }

    private static async Task<IResult> HandleLogin(LoginRequest request, IUserRepository userRepository,
        IJwtTokenService jwtTokenService, IMapper mapper)
    {
        if (await userRepository.GetUserByEmail(request.Email) is not { } user) throw new EmailGivenNotFoundException();
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) throw new InvalidPasswordException();

        var authResponse = new AuthenticationResponse(
            mapper.Map<UserResponse>(user),
            jwtTokenService.GenerateToken(user)
        );

        return Results.Ok(new StandardSuccessResponse<AuthenticationResponse>(authResponse));
    }
    #endregion
}