using AutoMapper;
using IbgeDesafioPleno.Application.Core;
using IbgeDesafioPleno.Application.Interfaces;
using IbgeDesafioPleno.Application.ViewModels;
using IbgeDesafioPleno.Domain.Entities;
using IbgeDesafioPleno.Domain.Interfaces;
using IbgeDesafioPleno.Domain.Transactions;

namespace IbgeDesafioPleno.Application.Services;

public sealed class LocaleService : BaseService<Locale, ILocaleRepository>, ILocaleService
{
    public LocaleService(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ILocaleRepository repository
        ) : base(mapper, unitOfWork, repository)
    { }

    #region Queries
    public async Task<IEnumerable<LocaleResponseViewModel>> GetAllAsync()
        => _mapper.Map<IEnumerable<LocaleResponseViewModel>>
        (await _repository.GetAllAsync());

    public async Task<LocaleResponseViewModel> GetByCityAsync(string city)
        => _mapper.Map<LocaleResponseViewModel>
        (await _repository.GetOneAsync(l => l.City.CityTyped == city));

    public async Task<LocaleResponseViewModel> GetByIbgeCodeAsync(string code)
        => _mapper.Map<LocaleResponseViewModel>
        (await _repository.GetOneAsync(l => l.Id.Code == code));

    public async Task<IEnumerable<LocaleResponseViewModel>> GetByStateAsync(string state)
        => _mapper.Map<IEnumerable<LocaleResponseViewModel>>
        (await _repository.GetManyWhereAsync(l => l.State.ToString() == state));
    #endregion

    #region Commands
    public async Task<ServiceResponse> CreateAsync(CreateLocaleRequestViewModel viewModel)
    {
        var localeExists = await _repository
            .GetOneAsync(locale => locale.Id.Code == viewModel.Id);

        if (localeExists is not null)
        {
            AddNotification("Locale", $"O local com o Id {viewModel.Id} já existe.");
            return new ServiceResponse(false, Notifications.ToList());
        }

        var locale = _mapper.Map<Locale>(viewModel);

        if (!locale.IsValid)
            return new ServiceResponse(false, locale.Notifications);

        await _repository.AddAsync(locale);
        if (await _unitOfWork.SaveChangesAsync() <= 0)
        {
            AddNotification("Locale", "Não foi possível salvar esse Local.");
            return new ServiceResponse(false, Notifications.ToList());
        }

        return new ServiceResponse(true, "Local salvo com sucesso!");
    }

    public async Task<ServiceResponse> UpdateAsync(string ibgeCode, EditLocaleRequestViewModel viewModel)
    {
        var localeExists = await _repository
            .GetOneAsync(locale => locale.City.CityTyped == viewModel.City
            && locale.State.ToString() == viewModel.State
            && locale.Id.Code != ibgeCode);

        if (localeExists is not null)
        {
            AddNotification("Locale", $"Um local com a cidade {viewModel.City} e {viewModel.State} já existe.");
            return new ServiceResponse(false, Notifications.ToList());
        }

        var locale = await _repository
            .GetOneAsync(locale => locale.Id.Code == ibgeCode);

        if (locale is null)
        {
            AddNotification("Locale", $"O local com o Id {ibgeCode} não existe.");
            return new ServiceResponse(false, Notifications.ToList());
        }

        var localeUpdated = _mapper.Map(viewModel, locale);

        if (!localeUpdated!.IsValid)
            return new ServiceResponse(false, localeUpdated.Notifications);

        _repository.Update(localeUpdated);
        if (await _unitOfWork.SaveChangesAsync() <= 0)
        {
            AddNotification("Locale", "Não foi possível alterar esse Local.");
            return new ServiceResponse(false, Notifications.ToList());
        }

        return new ServiceResponse(true, "Local alterado com sucesso!");
    }

    public async Task<ServiceResponse> DeleteAsync(string ibgeCode)
    {
        var localeExists = await _repository
            .GetOneAsync(locale => locale.Id.Code == ibgeCode);

        if (localeExists is null)
        {
            AddNotification("Locale", $"O local com o Id {ibgeCode} não existe.");
            return new ServiceResponse(false, Notifications.ToList());
        }

        _repository.Remove(localeExists);
        if (await _unitOfWork.SaveChangesAsync() <= 0)
        {
            AddNotification("Locale", "Não foi possível deletar esse Local.");
            return new ServiceResponse(false, Notifications.ToList());
        }

        return new ServiceResponse(true, "Local deletado com sucesso!");
    }
    #endregion
}