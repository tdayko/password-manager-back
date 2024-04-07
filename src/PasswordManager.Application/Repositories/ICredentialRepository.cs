using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Repositories;

public interface ICredentialRepository
{
    void AddCredential(Credential credential);
    Credential? GetCredentialById(Guid id);
}