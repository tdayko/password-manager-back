using Microsoft.EntityFrameworkCore;
using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;
using PasswordManager.Infra.DbContext;

namespace PasswordManager.Infra.Repositories;

public class CredentialRepository(PasswordManagerContext context) : ICredentialRepository
{
    private readonly PasswordManagerContext _context = context;

    public async Task AddCredential(Credential credential) 
    {
        await _context.Credentials!.AddAsync(credential);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Credential?> GetCredentialById(Guid credentialId) 
        => await _context.Credentials!.SingleOrDefaultAsync(credential => credential.Id == credentialId);
    
    public async Task<Credential?> GetUserCredentialById(Guid credentialId, Guid userId)
        => await _context.Credentials!.SingleOrDefaultAsync(credential => credential.Id == credentialId && credential.User.Id == userId);

    public async Task<List<Credential>> GetAllUserCredentials(Guid userId) 
        => await _context.Credentials.Include(u => u.User).Where(x => x.User.Id == userId).ToListAsync();
}