using IbgeDesafioPleno.Application.Core;
using IbgeDesafioPleno.Application.ViewModels;
using IbgeDesafioPleno.Domain.Entities;
using IbgeDesafioPleno.Domain.Interfaces;

namespace IbgeDesafioPleno.Application.Interfaces;

public interface ILocaleService : IBaseService<Locale, ILocaleRepository>
{
    Task<IEnumerable<LocaleResponseViewModel>> GetAllAsync();
    Task<IEnumerable<LocaleResponseViewModel>> GetByStateAsync(string state);
    Task<LocaleResponseViewModel> GetByCityAsync(string city);
    Task<LocaleResponseViewModel> GetByIbgeCodeAsync(string code);

    Task<ServiceResponse> CreateAsync(CreateLocaleRequestViewModel viewModel);
    Task<ServiceResponse> UpdateAsync(string ibgeCode, EditLocaleRequestViewModel viewModel);
    Task<ServiceResponse> DeleteAsync(string ibgeCode);
}