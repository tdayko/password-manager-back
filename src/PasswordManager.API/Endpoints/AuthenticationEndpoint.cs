using AutoMapper;
using PasswordManager.Domain.Entities;

using PasswordManager.Application.Contracts.Responses; 
using PasswordManager.Application.Services;
using PasswordManager.Application.Contracts.Requests;
using PasswordManager.Application.Repositories;
using PasswordManager.Application.Errors;
using PasswordManager.Application.Contracts;

namespace PasswordManager.API.Endpoints;

public static class AuthenticationEndpoint
{
    public static IEndpointRouteBuilder AddAuthenticationEndpoint(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder authEndpoint = app.MapGroup("password-manager/api/auth");

        // register
        authEndpoint.MapPost("register", async (RegisterRequest request, IUserRepository repository, IJwtTokenService jwtTokenService, IMapper mapper) 
            => await HandleRegister(request, repository, jwtTokenService, mapper)
        )
        .WithName("Register")
        .Produces<StandardSuccessResponse<AuthenticationResponse>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Register to the Password Manager API";
            x.Description = "Register to the Password Manager API with your credentials";
            return x;
        });

        // login
        authEndpoint.MapPost("login", async (LoginRequest request, IUserRepository repository, IJwtTokenService jwtTokenService, IMapper mapper) 
            => await HandleLogin(request, repository, jwtTokenService, mapper)
        )
        .WithName("Login")
        .Produces<StandardSuccessResponse<AuthenticationResponse>>()
        .WithOpenApi(x =>
        {
            x.Summary = "Login to the Password Manager API";
            x.Description = "Login to the Password Manager API with your credentials";
            return x;
        });

        return app;
    }

    public static async Task<IResult> HandleRegister(RegisterRequest request, IUserRepository repository, IJwtTokenService jwtTokenService, IMapper mapper)
    {
        if (repository.GetUserByEmail(request.Email) != null)
        {
            throw new DuplicateEmailException();
        }
        
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

    public static async Task<IResult> HandleLogin(LoginRequest request, IUserRepository repository, IJwtTokenService jwtTokenService, IMapper mapper)
    {
        if (repository.GetUserByEmail(request.Email) is not User user)
        {
            throw new EmailGivenNotFoundException();
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new InvalidPasswordException();
        }

        var authResponse = new AuthenticationResponse(
            mapper.Map<UserResponse>(user), 
            jwtTokenService.GenerateToken(user)
        );
        
        return Results.Ok(mapper.Map<StandardSuccessResponse<AuthenticationResponse>>(authResponse));
    }
}