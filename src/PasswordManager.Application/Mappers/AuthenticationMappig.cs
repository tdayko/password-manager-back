using AutoMapper;
using PasswordManager.Application.Contracts.Requests.Authentication;
using PasswordManager.Application.Contracts.Responses;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Mappers;

public class AuthenticationMapping : Profile
{
    public AuthenticationMapping()
    {
        CreateMap<RegisterRequest, User>()
            .ConvertUsing(request => new User(
                request.Username,
                request.Password,
                request.Email
            ));

        CreateMap<User, UserResponse>()
            .ConvertUsing(user => new UserResponse(
                user.Id,
                user.UserName,
                user.Email
            ));
    }
}