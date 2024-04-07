using AutoMapper;
using PasswordManager.Application.Contracts.Responses;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Mappers;

public class CredentialMapping : Profile
{
    public CredentialMapping()
    {
        CreateMap<Credential, CredentialResponse>()
            .ConstructUsing(credential => new CredentialResponse(
                credential.User.Id,
                credential.Username,
                credential.Email,
                credential.Password,
                credential.WebSite,
                credential.CredentialName
            ));
    }
}