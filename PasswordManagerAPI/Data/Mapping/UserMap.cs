using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManagerAPI.Models;

namespace PasswordManagerAPI.Data.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        /* tabela user */
        builder.ToTable("User");
        
        /* primary key */
        builder.HasKey(x => x.Id);

        /* identity */
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        /* properties */
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasColumnName("Name")
            .HasMaxLength(80);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasColumnName("PasswordHash")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);
        
        /* um para muitos */
        builder.HasMany(x => x.Credentials);

        /* index */
        builder.HasIndex(x => x.Id)
            .IsUnique();
        
        builder.HasIndex(x => x.Email)
            .IsUnique();
    }
}