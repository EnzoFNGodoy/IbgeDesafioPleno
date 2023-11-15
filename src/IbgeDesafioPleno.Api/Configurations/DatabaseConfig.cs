using IbgeDesafioPleno.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace IbgeDesafioPleno.Api.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        string ibgeCodeConnection = configuration.GetConnectionString("IbgeDesafioConnection")!;

        services.AddDbContext<IbgeDbContext>(options =>
        {
            options.UseMySql(ibgeCodeConnection, ServerVersion.AutoDetect(ibgeCodeConnection),
                options => options.EnableRetryOnFailure())
            .EnableSensitiveDataLogging();
        });
    }
}