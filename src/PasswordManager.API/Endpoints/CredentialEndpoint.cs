using AutoMapper;

using PasswordManager.Application.Contracts.Requests.Credential;
using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.API.Endpoints;

public static class CredentialEndpoint
{
    public static IEndpointRouteBuilder AddCredentialEndpoint(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder credentialEndpoint = app.MapGroup("password-manager/api/credetials/");

        credentialEndpoint.MapPost("add", async (AddCredentialRequest request, ICredentialRepository repository, IMapper mapper)
            => await HandleAddCredential(request, repository, mapper)
        )
        .RequireAuthorization();

        return app;
    }

    private static async Task<IResult> HandleAddCredential(AddCredentialRequest request, ICredentialRepository repository, IMapper mapper)
    {
        return Results.Ok();
    }
}