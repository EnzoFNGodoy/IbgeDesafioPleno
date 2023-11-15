using IbgeDesafioPleno.Application.AutoMapper;

namespace IbgeDesafioPleno.Api.Configurations;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(typeof(DomainToViewModelProfile), typeof(ViewModelToDomainProfile), typeof(GeneralMappingProfile));
    }
}