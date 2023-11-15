using IbgeDesafioPleno.Domain.Core;

namespace IbgeDesafioPleno.Application.Core;

public interface IBaseService<T, TRepository>
    where T : Entity
    where TRepository : IBaseRepository<T>
{ }