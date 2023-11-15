using Flunt.Validations;
using IbgeDesafioPleno.Domain.Core;
using IbgeDesafioPleno.Domain.Helper;

namespace IbgeDesafioPleno.Domain.ValueObjects;

public sealed class IbgeCode : ValueObject
{
    private IbgeCode()
    { }

    public IbgeCode(string code)
    {
        Code = code;
        Validate();
    }

    public string Code { get; private set; } = string.Empty;

    protected override void Validate()
        => AddNotifications(new Contract<IbgeCode>()
            .Requires()
            .IsTrue(!Code.IsNumeric(), "IbgeCode.Code", "The code should be numeric.")
            .IsTrue(Code.Length is not 7, "IbgeCode.Code", "The code should contains 7 characters.")
            );
}