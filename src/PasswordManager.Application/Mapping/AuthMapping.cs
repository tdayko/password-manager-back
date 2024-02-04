using AutoMapper;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Application.Contracts;

namespace PasswordManager.Application.Mapping;

public class AuthMapping : Profile
{
    public AuthMapping()
    {
        CreateMap<RegisterRequest, RegisterCommand>().ReverseMap();
        CreateMap<LoginRequest, LoginQuery>().ReverseMap();
    }
}