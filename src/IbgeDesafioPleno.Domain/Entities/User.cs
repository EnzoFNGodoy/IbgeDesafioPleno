using BytenFoods.Domain.ValueObjects;
using IbgeDesafioPleno.Domain.Core;
using IbgeDesafioPleno.Domain.ValueObjects;

namespace IbgeDesafioPleno.Domain.Entities;

public sealed class User : Entity
{
    private User()
    { }

    public User(
        Guid id,
        Email email,
        Username username,
        Password password)
    {
        Id = id;
        Email = email;
        Username = username;
        Password = password;
        Validate();
    }

    public Guid Id { get; private set; }
    public Email Email { get; private set; } = default!;
    public Username Username { get; private set; } = default!;
    public Password Password { get; private set; } = default!;

    protected override void Validate()
    {
        AddNotifications(Email);
        AddNotifications(Username);
        AddNotifications(Password);
    }
}