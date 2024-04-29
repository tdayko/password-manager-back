using Microsoft.EntityFrameworkCore;
using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;
using PasswordManager.Infra.DbContext;

namespace PasswordManager.Infra.Repositories;

public class UserRepository(PasswordManagerContext context) : IUserRepository
{
    private readonly PasswordManagerContext _context = context;

    public async Task AddUser(User user)
    {
        await _context.Users!.AddAsync(user);
        await _context.SaveChangesAsync();
    }
    public async Task<User?> GetUserByEmail(string email)
        => await _context.Users!.SingleOrDefaultAsync(x => x.Email == email);

    public async Task<User?> GetUserByUserId(Guid userId)
        => await _context.Users!.SingleOrDefaultAsync(x => x.Id == userId);

}