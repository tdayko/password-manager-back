using AutoMapper;
using PasswordManager.Application.Contracts.Responses;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Mappers;

public class CredentialMapping : Profile
{
    public CredentialMapping()
    {
        CreateMap<Credential, CredentialResponse>()
            .ConvertUsing(credential => new CredentialResponse(
                credential.Id,
                credential.Username,
                credential.Email,
                credential.Password,
                credential.WebSite.ToString()
            ));
    }
}