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
        CreateMap<RegisterRequest, RegisterCommand>().ReverseMap();
        CreateMap<LoginRequest, LoginQuery>().ReverseMap();

        CreateMap<User, UserResponse>().ReverseMap();

        CreateMap<AuthenticationResult, StandardSuccessResponse<UserResponse>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}