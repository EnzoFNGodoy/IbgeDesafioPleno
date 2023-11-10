using BytenFoods.Domain.Helpers;
using Flunt.Validations;
using IbgeDesafioPleno.Domain.Core;

namespace IbgeDesafioPleno.Domain.ValueObjects;

public sealed class City : ValueObject
{
    private City()
    { }

    public City(string cityTyped)
    {
        CityTyped = cityTyped;
        Validate();
    }

    public string CityTyped { get; private set; } = string.Empty;

    protected override void Validate()
        => AddNotifications(new Contract<City>()
        .Requires()
        .IsTrue(!CityTyped.IsEmpty(), "City.CityTyped", "The city cannot be empty.")
        .IsLowerOrEqualsThan(CityTyped.Length, 50, "City.CityTyped", "The city must contain less than 50 characters.")
        .IsGreaterOrEqualsThan(CityTyped.Length, 3, "City.CityTyped", "The city must contain more than 3 characters.")
        );
}