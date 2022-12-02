using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManagerAPI.Models;

namespace PasswordManagerAPI.Data.Mapping;

public class CredentialMapping : IEntityTypeConfiguration<Credential>
{
    public void Configure(EntityTypeBuilder<Credential> builder)
    {
        builder.HasKey(x => x.Id);

        /* properties */
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("Password")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.Uri)
            .IsRequired()
            .HasColumnName("Uri")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        /* index */
        builder.HasIndex(x => x.Id)
            .IsUnique();
        builder.HasIndex(x => x.Name);
    }
}