using BytenFoods.Domain.Helpers;
using Flunt.Validations;
using IbgeDesafioPleno.Domain.Core;

namespace BytenFoods.Domain.ValueObjects;

public sealed class Password : ValueObject
{
    private Password() : base()
    { }

    private Password(string passwordTyped)
    {
        PasswordTyped = passwordTyped;
        Validate();
    }

    public string PasswordTyped { get; init; } = string.Empty;

    protected override void Validate()
       => AddNotifications(new Contract<Password>()
           .Requires()
           .IsTrue(!PasswordTyped.IsEmpty(), "Password.PasswordTyped", "The password cannot be empty.")
           .IsLowerThan(6, PasswordTyped.Length, "Password.PasswordTyped", "The password must contains more than 6 characters.")
           .IsGreaterThan(16, PasswordTyped.Length, "Password.PasswordTyped", "The password must contains less than 16 characters.")
           .IsTrue(ValidateFormat(), "Password.PasswordTyped", "The password must contains at least one upper case, one lower case, one number and one special character.")
           );
    private bool ValidateFormat()
       => PasswordTyped.HasUpperCase()
       && PasswordTyped.HasLowerCase()
       && PasswordTyped.HasSpecialChar()
       && PasswordTyped.HasNumber();

    public override string ToString() 
        => PasswordTyped;
}