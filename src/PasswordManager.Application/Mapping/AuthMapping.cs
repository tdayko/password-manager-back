using AutoMapper;

using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Mapping;

public class AuthMapping : Profile
{
    public AuthMapping()
    {
        CreateMap<RegisterRequest, RegisterCommand>().ReverseMap();
        CreateMap<LoginRequest, LoginQuery>().ReverseMap();

        CreateMap<User, UserResponse>().ReverseMap();
    }
}