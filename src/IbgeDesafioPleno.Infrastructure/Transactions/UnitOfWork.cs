using IbgeDesafioPleno.Domain.Transactions;
using IbgeDesafioPleno.Infrastructure.Context;

namespace IbgeDesafioPleno.Infrastructure.Transactions;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly IbgeDbContext _context;

    public UnitOfWork(IbgeDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}