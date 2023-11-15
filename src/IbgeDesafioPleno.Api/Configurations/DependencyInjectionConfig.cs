﻿using IbgeDesafioPleno.IoC;

namespace IbgeDesafioPleno.Api.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        NativeInjector.RegisterServices(services);
    }
}