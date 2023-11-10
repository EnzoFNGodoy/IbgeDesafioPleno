using BytenFoods.Domain.Helpers;
using Flunt.Validations;
using IbgeDesafioPleno.Domain.Core;

namespace IbgeDesafioPleno.Domain.ValueObjects;

public sealed class Username : ValueObject
{
    private Username()
    { }

    public Username(string usernameTyped)
    {
        UsernameTyped = usernameTyped;
        Validate();
    }

    public string UsernameTyped { get; private set; } = string.Empty;

    protected override void Validate()
        => AddNotifications(new Contract<Username>()
            .Requires()
            .IsTrue(UsernameTyped.IsNotEmpty(), "Username.UsernameTyped", "Username cannot be empty.")
            );
}