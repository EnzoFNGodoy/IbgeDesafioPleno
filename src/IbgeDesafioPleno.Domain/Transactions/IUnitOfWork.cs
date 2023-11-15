namespace IbgeDesafioPleno.Domain.Transactions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}