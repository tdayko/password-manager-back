using System.Security.Claims;
using PasswordManagerAPI.Models;

namespace PasswordManagerAPI.Extensions;

public static class UserClaimExtension
{
    // claims do usuário
    public static IEnumerable<Claim> GetClaim(this User user) 
        => new Claim[]{new (ClaimTypes.Name, user.Email)};
}