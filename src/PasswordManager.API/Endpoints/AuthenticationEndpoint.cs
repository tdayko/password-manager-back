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
            .WithTags("Authentication");

        // register
        authEndpoint.MapPost("register",
                async (RegisterRequest request, IUserRepository repository, IJwtTokenService jwtTokenService,
                        IMapper mapper)
                    => await HandleRegister(request, repository, jwtTokenService, mapper)
            )
            .WithName("Register")
            .Produces<StandardSuccessResponse<AuthenticationResponse>>()
            .WithOpenApi(x =>
            {
                x.Summary = "Register new user";
                return x;
            });

        // login
        authEndpoint.MapPost("login",
                async (LoginRequest request, IUserRepository repository, IJwtTokenService jwtTokenService,
                        IMapper mapper)
                    => await HandleLogin(request, repository, jwtTokenService, mapper)
            )
            .WithName("Login")
            .Produces<StandardSuccessResponse<AuthenticationResponse>>()
            .WithOpenApi(x =>
            {
                x.Summary = "Login user";
                return x;
            });

        return app;
    }

    private static async Task<IResult> HandleRegister(RegisterRequest request, IUserRepository repository,
        IJwtTokenService jwtTokenService, IMapper mapper)
    {
        if (repository.GetUserByEmail(request.Email) != null) throw new DuplicateEmailException();

        request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = mapper.Map<User>(request);
        jwtTokenService.GenerateToken(user);

        var authResponse = new AuthenticationResponse(
            mapper.Map<UserResponse>(user),
            jwtTokenService.GenerateToken(user)
        );

        repository.AddUser(user);
        return Results.Ok(mapper.Map<StandardSuccessResponse<AuthenticationResponse>>(authResponse));
    }

    private static async Task<IResult> HandleLogin(LoginRequest request, IUserRepository repository,
        IJwtTokenService jwtTokenService, IMapper mapper)
    {
        if (repository.GetUserByEmail(request.Email) is not User user) throw new EmailGivenNotFoundException();

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) throw new InvalidPasswordException();

        var authResponse = new AuthenticationResponse(
            mapper.Map<UserResponse>(user),
            jwtTokenService.GenerateToken(user)
        );

        return Results.Ok(mapper.Map<StandardSuccessResponse<AuthenticationResponse>>(authResponse));
    }
}