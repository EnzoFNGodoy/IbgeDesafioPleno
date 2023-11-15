using IbgeDesafioPleno.Application.Interfaces;
using IbgeDesafioPleno.Application.Services;
using IbgeDesafioPleno.Domain.Interfaces;
using IbgeDesafioPleno.Domain.Transactions;
using IbgeDesafioPleno.Infrastructure.Context;
using IbgeDesafioPleno.Infrastructure.Repositories;
using IbgeDesafioPleno.Infrastructure.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace IbgeDesafioPleno.IoC;

public static class NativeInjector
{
    public static void RegisterServices(IServiceCollection services)
    {
        RegisterApplicationServices(services);
        RegisterInfrastructureServices(services);
        RegisterDomainServices(services);
    }

    private static void RegisterApplicationServices(IServiceCollection services)
    {
        // Application - Services
        services.AddScoped<ILocaleService, LocaleService>();
    }

    private static void RegisterInfrastructureServices(IServiceCollection services)
    {
        // Infra - Data
        services.AddScoped<IbgeDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Infra - Repositories
        services.AddScoped<ILocaleRepository, LocaleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void RegisterDomainServices(IServiceCollection services)
    { }
}