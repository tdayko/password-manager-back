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
        var credentialEndpoint = app.MapGroup("password-manager/api/credentials")
            .WithTags("Credential");
        
        // add credential
        credentialEndpoint.MapPost("/", HandleAddCredential)
            .WithName("Add Credential")
            .Produces<StandardSuccessResponse<CredentialResponse>>()
            .WithOpenApi(x =>
            {
                x.Summary = "Add a new credential";
                return x;
            });
        
        credentialEndpoint.MapGet("/{credentialId}", HandleGetUserCredentialById)
            .WithName("Get User Credential by Id")
            .Produces<StandardSuccessResponse<CredentialResponse>>()
            .WithOpenApi(x =>
            {
                x.Summary = "Get User Credential by Id";
                return x;
            });

        credentialEndpoint.MapGet("/", HandleGetAllUserCredentials)
            .WithName("Get All User Credentials")
            .Produces<StandardSuccessResponse<List<CredentialResponse>>>()
            .WithOpenApi(x => 
            {
                x.Summary = "Get All User Credentials";
                return x;
            });
        
        return app;
    }

    #region private methods

    private static async Task<IResult> HandleGetAllUserCredentials(
        HttpContext context,
        ICredentialRepository credentialRepository,
        IMapper mapper)
    {
        if (!context.User.Identity!.IsAuthenticated) throw new UnauthenticatedUserException();
        var userId = Guid.Parse(context.User.FindFirstValue("name")!);

        var credentials = credentialRepository.GetAllUserCredentials(userId);
        if (credentials.Count == 0) throw new NoCredentialsWereFoundException();

        var credentialsResponses = mapper.Map<List<CredentialResponse>>(credentials);
        return Results.Ok(new StandardSuccessResponse<List<CredentialResponse>>(credentialsResponses));
    }
    private static async Task<IResult> HandleGetUserCredentialById(
        string credentialId, 
        HttpContext context, 
        ICredentialRepository credentialRepository, 
        IMapper mapper)
    {
        if (!context.User.Identity!.IsAuthenticated) throw new UnauthenticatedUserException();
        
        var userId = Guid.Parse(context.User.FindFirstValue("name")!);
        var credential = credentialRepository.GetUserCredentialById(Guid.Parse(credentialId), userId);
        
        if (credential is null) throw new CredentialNotFoundException();
        
        var credentialResponse = mapper.Map<CredentialResponse>(credential);
        return Results.Ok(new StandardSuccessResponse<CredentialResponse>(credentialResponse));
    }
    
    private static async Task<IResult> HandleAddCredential(
        AddCredentialRequest request, 
        HttpContext context,
        IUserRepository userRepository, IMapper mapper, 
        ICredentialRepository credentialRepository
        )
    { 
        if (!context.User.Identity!.IsAuthenticated) throw new UnauthenticatedUserException();
        
        var user = userRepository!.GetUserByUserId(Guid.Parse(context.User.FindFirstValue("name")!))!;
        var credential = new Credential(user, request.Username, request.Email, request.Password, request.WebSite);
        credentialRepository.AddCredential(credential);

        var credentialResponse = mapper.Map<CredentialResponse>(credential);
        return Results.Ok(new StandardSuccessResponse<CredentialResponse>(credentialResponse));
    }
    
    #endregion
}