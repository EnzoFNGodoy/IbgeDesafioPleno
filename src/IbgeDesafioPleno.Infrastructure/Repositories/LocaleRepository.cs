using IbgeDesafioPleno.Domain.Entities;
using IbgeDesafioPleno.Domain.Interfaces;
using IbgeDesafioPleno.Infrastructure.Context;
using IbgeDesafioPleno.Infrastructure.Core;

namespace IbgeDesafioPleno.Infrastructure.Repositories;

public sealed class LocaleRepository : BaseRepository<Locale>, ILocaleRepository
{
    public LocaleRepository(IbgeDbContext context) 
        : base(context)
    { }
}