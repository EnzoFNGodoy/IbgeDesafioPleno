using Flunt.Notifications;

namespace IbgeDesafioPleno.Domain.Core;

public abstract class Entity : Notifiable<Notification>
{
    protected abstract void Validate();
}