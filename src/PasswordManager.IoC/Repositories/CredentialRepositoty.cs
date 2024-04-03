using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.IoC.Repositories;

public class CredentialRepository : ICredentialRepository
{
    private static readonly List<Credential> Credentials = [];

    public void AddCredential(Credential credential)
    {
        Credentials.Add(credential);
    }

    public Credential? GetCredentialById(Guid id)
    {
        return Credentials.SingleOrDefault(x => x.Id == id);
    }
}