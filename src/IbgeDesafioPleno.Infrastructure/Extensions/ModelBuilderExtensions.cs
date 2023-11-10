using IbgeDesafioPleno.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace IbgeDesafioPleno.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConfigureMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new LocaleMap());
    }
}