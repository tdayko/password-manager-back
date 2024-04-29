using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Repositories;

public interface ICredentialRepository
{
    Task AddCredential(Credential credential);
    Task<Credential?> GetCredentialById(Guid credentialId);
    Task<Credential?> GetUserCredentialById(Guid credentialId, Guid userId);
    Task<List<Credential>> GetAllUserCredentials(Guid userId);
}