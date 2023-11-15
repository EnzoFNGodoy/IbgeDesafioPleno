using AutoMapper;
using IbgeDesafioPleno.Application.ViewModels;
using IbgeDesafioPleno.Domain.Entities;

namespace IbgeDesafioPleno.Application.AutoMapper;

public sealed class DomainToViewModelProfile : Profile
{
    public DomainToViewModelProfile()
    {
        CreateMap<Locale, LocaleResponseViewModel>();
    }
}