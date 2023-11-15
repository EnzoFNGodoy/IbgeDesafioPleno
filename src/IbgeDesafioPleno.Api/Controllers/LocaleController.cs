using IbgeDesafioPleno.Api.Core;
using IbgeDesafioPleno.Application.Interfaces;
using IbgeDesafioPleno.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IbgeDesafioPleno.Api.Controllers;

[Route("api/v1/locales")]
[AllowAnonymous]
//[Authorize] --> Autorização / Autenticação
public sealed class LocaleController : ApiController
{
    private readonly ILocaleService _localeService;

    public LocaleController(ILocaleService localeService)
    {
        _localeService = localeService;
    }

    /// <summary>
    /// Gets all Locales.
    /// </summary>
    /// <returns>A list of <see cref="LocaleResponseViewModel"/> object that represents the Locales.</returns>

    [HttpGet]
    public async Task<IEnumerable<LocaleResponseViewModel>> GetAllAsync()
        => await _localeService.GetAllAsync();

    [HttpGet("byCode/{ibgeCode}")]
    public async Task<LocaleResponseViewModel> GetByCodeAsync(string ibgeCode)
        => await _localeService.GetByIbgeCodeAsync(ibgeCode);

    [HttpGet("byCity/{city}")]
    public async Task<LocaleResponseViewModel> GetByCityAsync(string city)
        => await _localeService.GetByCityAsync(city);

    [HttpGet("byState/{state}")]
    public async Task<IEnumerable<LocaleResponseViewModel>> GetByStateAsync(string state)
        => await _localeService.GetByStateAsync(state);

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateLocaleRequestViewModel viewModel)
        => CustomResponse(await _localeService.CreateAsync(viewModel));

    [HttpPut("{ibgeCode}")]
    public async Task<IActionResult> UpdateAsync(string ibgeCode, [FromBody] EditLocaleRequestViewModel viewModel)
        => CustomResponse(await _localeService.UpdateAsync(ibgeCode, viewModel));

    [HttpDelete("{ibgeCode}")]
    public async Task<IActionResult> DeleteAsync(string ibgeCode)
        => CustomResponse(await _localeService.DeleteAsync(ibgeCode));
}