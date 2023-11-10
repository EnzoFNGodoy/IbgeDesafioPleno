using IbgeDesafioPleno.Domain.Entities;
using IbgeDesafioPleno.Domain.Interfaces;
using IbgeDesafioPleno.Infrastructure.Context;
using IbgeDesafioPleno.Infrastructure.Core;

namespace IbgeDesafioPleno.Infrastructure.Repositories;

public sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IbgeDbContext context) 
        : base(context)
    { }
}