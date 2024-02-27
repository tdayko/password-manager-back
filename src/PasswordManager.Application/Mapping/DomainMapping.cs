using AutoMapper;

using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Application.Contracts;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Mapping;

public class DomainMapping : Profile
{
    public DomainMapping()
    {
        CreateMap<RegisterRequest, RegisterCommand>()
            .ConstructUsing(request => new RegisterCommand(request.Username, request.Email, request.Password));

        CreateMap<LoginRequest, LoginQuery>()
            .ConstructUsing(request => new LoginQuery(request.Email, request.Password));

        CreateMap<User, UserResponse>().ConvertUsing(user => new UserResponse(user.Id, user.Username, user.Email));

        CreateMap<AuthenticationResult, StandardSuccessResponse<AuthenticationResult>>()
            .ConstructUsing(authResult => new StandardSuccessResponse<AuthenticationResult>(authResult));
    }
}