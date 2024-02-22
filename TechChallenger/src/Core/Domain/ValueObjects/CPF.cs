using Domain.Base;

namespace Domain.ValueObjects;

public class CPF : ValueObject
{
    public CPF(string number)
    {
        Number = number;
    }

    public string Number { get; private set; }
}