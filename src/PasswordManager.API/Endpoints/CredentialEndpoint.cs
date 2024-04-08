using System.Security.Claims;
using AutoMapper;
using PasswordManager.Application.Contracts.Requests.Credential;
using PasswordManager.Application.Contracts.Responses;
using PasswordManager.Application.Errors;
using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.API.Endpoints;

public static class CredentialEndpoint
{
    public static IEndpointRouteBuilder AddCredentialEndpoint(this IEndpointRouteBuilder app)
    {
        var credentialEndpoint = app.MapGroup("password-manager/api/credetials/")
            .WithTags("Credential");

        credentialEndpoint.MapPost("add", async (
                    HttpContext context,
                    AddCredentialRequest request,
                    ICredentialRepository credentialRepository,
                    IUserRepository userRepository,
                    IMapper mapper
                ) => await HandleAddCredential(context, request, credentialRepository, userRepository, mapper)
            )
            .WithName("Add Credential")
            .Produces<StandardSuccessResponse<CredentialResponse>>()
            .WithOpenApi(x =>
            {
                x.Summary = "Add a new credential";
                return x;
            });

        return app;
    }

    private static async Task<IResult> HandleAddCredential(
        HttpContext context,
        AddCredentialRequest request,
        ICredentialRepository credentialRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        if (!context.User.Identity!.IsAuthenticated)
        {
            throw new UnauthenticatedUserException();
        }

        var user = userRepository!.GetUserByUserId(Guid.Parse(context.User.FindFirstValue("name")!))!;
        var credential = new Credential(user, request.Username, request.Email, request.Password, request.WebSite.Host);
        credentialRepository.AddCredential(credential);

        var credentialResponse = mapper.Map<CredentialResponse>(credential);
        return Results.Ok(new StandardSuccessResponse<CredentialResponse>(credentialResponse));
    }
}