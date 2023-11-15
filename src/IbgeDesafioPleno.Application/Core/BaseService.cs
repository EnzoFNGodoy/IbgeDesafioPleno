using AutoMapper;
using Flunt.Notifications;
using IbgeDesafioPleno.Domain.Core;
using IbgeDesafioPleno.Domain.Transactions;

namespace IbgeDesafioPleno.Application.Core;

public abstract class BaseService<T, TRepository> : Notifiable<Notification>, 
    IBaseService<T, TRepository>
    where T : Entity
    where TRepository : IBaseRepository<T>
{
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly TRepository _repository;

    public BaseService(IMapper mapper, IUnitOfWork unitOfWork, TRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
}