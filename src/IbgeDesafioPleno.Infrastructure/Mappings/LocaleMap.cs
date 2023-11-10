using IbgeDesafioPleno.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeDesafioPleno.Infrastructure.Mappings;

public sealed class LocaleMap : IEntityTypeConfiguration<Locale>
{
    public void Configure(EntityTypeBuilder<Locale> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Id)
            .IsUnique();

        builder.OwnsOne(locale => locale.Id, code =>
        {
            code.Property(c => c.Code)
            .HasColumnType("char(7)")
            .HasColumnName("Id");

            code.Ignore(c => c.Notifications);
        });

        builder.OwnsOne(locale => locale.City, city =>
        {
            city.Property(c => c.CityTyped)
            .HasColumnType("varchar(150)")
            .HasColumnName("City");

            city.Ignore(c => c.Notifications);
        });

        builder.Ignore(x => x.Notifications);
    }
}