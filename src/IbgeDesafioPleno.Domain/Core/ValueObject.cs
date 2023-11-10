using Flunt.Notifications;

namespace IbgeDesafioPleno.Domain.Core;

public abstract class ValueObject : Notifiable<Notification>
{
    protected abstract void Validate();
}