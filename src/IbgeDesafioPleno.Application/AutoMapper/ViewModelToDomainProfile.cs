using AutoMapper;
using IbgeDesafioPleno.Application.ViewModels;
using IbgeDesafioPleno.Domain.Entities;

namespace IbgeDesafioPleno.Application.AutoMapper;

public sealed class ViewModelToDomainProfile : Profile
{
    public ViewModelToDomainProfile()
    {
        CreateMap<CreateLocaleRequestViewModel, Locale>();
        CreateMap<EditLocaleRequestViewModel, Locale>();
    }
}