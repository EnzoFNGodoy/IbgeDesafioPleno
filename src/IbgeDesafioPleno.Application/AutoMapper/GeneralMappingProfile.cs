using AutoMapper;
using IbgeDesafioPleno.Domain.ValueObjects;

namespace IbgeDesafioPleno.Application.AutoMapper;

public sealed class GeneralMappingProfile : Profile
{
    public GeneralMappingProfile()
    {
        CreateMap<IbgeCode, string>()
            .ConstructUsing(ibgeCode => ibgeCode.Code);
        CreateMap<City, string>()
            .ConstructUsing(city => city.CityTyped);

        CreateMap<string, IbgeCode>()
            .ConstructUsing(text => new IbgeCode(text));
        CreateMap<string, City>()
            .ConstructUsing(text => new City(text));
    }
}