using IbgeDesafioPleno.Domain.Core;
using IbgeDesafioPleno.Domain.Enums;
using IbgeDesafioPleno.Domain.ValueObjects;

namespace IbgeDesafioPleno.Domain.Entities;

public sealed class Locale : Entity
{
    private Locale()
    { }

    public Locale(IbgeCode id, EState state, City city)
    {
        Id = id;
        State = state;
        City = city;
        Validate();
    }

    public IbgeCode Id { get; private set; } = default!;
    public EState State { get; private set; }
    public City City { get; private set; } = default!;

    protected override void Validate()
    {
        AddNotifications(Id);
        AddNotifications(City);
    }
}