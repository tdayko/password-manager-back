using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Repositories;

public interface ICredentialRepository
{
    void AddCredential(Credential credential);
    Credential? GetCredentialById(Guid credentialId);
    Credential? GetUserCredentialById(Guid credentialId, Guid userId);
    List<Credential> GetAllUserCredentials(Guid userId);
}