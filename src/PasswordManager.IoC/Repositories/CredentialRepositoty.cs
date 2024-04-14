using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.IoC.Repositories;

public class CredentialRepository : ICredentialRepository
{
    private static readonly List<Credential> Credentials = [];

    public void AddCredential(Credential credential) => Credentials.Add(credential);
    
    public Credential? GetCredentialById(Guid credentialId) 
        => Credentials.SingleOrDefault(credential => credential.Id == credentialId);
    
    public Credential? GetUserCredentialById(Guid credentialId, Guid userId)
        => Credentials.SingleOrDefault(credential => credential.Id == credentialId && credential.User.Id == userId);

    public List<Credential> GetAllUserCredentials(Guid userId)
        => Credentials.FindAll(credential => credential.User.Id == userId).ToList();
}