using IbgeDesafioPleno.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeDesafioPleno.Infrastructure.Mappings;

public sealed class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(x => x.Id);  

        builder
            .HasIndex(x => x.Email)
            .IsUnique();

        builder.OwnsOne(user => user.Email, email =>
        {
            email.Property(e => e.EmailAddress)
            .HasColumnType("varchar(150)")
            .HasColumnName("Email");

            email.Ignore(e => e.Notifications);
        });

        builder.OwnsOne(user => user.Username, username =>
        {
            username.Property(u => u.UsernameTyped)
            .HasColumnType("varchar(30)")
            .HasColumnName("Username");

            username.Ignore(u => u.Notifications);
        });

        builder.OwnsOne(user => user.Password, password =>
        {
            password.Property(p => p.PasswordTyped)
            .HasColumnType("varchar(16)")
            .HasColumnName("Password");

            password.Ignore(p => p.Notifications);
        });

        builder.Ignore(x => x.Notifications);
    }
}