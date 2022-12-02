using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManagerAPI.Models;

namespace PasswordManagerAPI.Data.Mapping;

public class CredentialMapping : IEntityTypeConfiguration<Credential>
{
    public void Configure(EntityTypeBuilder<Credential> builder)
    {
        
    }
}