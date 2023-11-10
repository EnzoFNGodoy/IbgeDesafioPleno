using Flunt.Notifications;
using IbgeDesafioPleno.Domain.Entities;
using IbgeDesafioPleno.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IbgeDesafioPleno.Infrastructure.Context;

public sealed class IbgeDbContext : DbContext
{
    public IbgeDbContext(DbContextOptions<IbgeDbContext> options)
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Locale> Locales => Set<Locale>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<List<Notification>>();

        modelBuilder.ConfigureMappings();
        base.OnModelCreating(modelBuilder);
    }
}