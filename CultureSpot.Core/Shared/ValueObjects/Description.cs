using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Shared.ValueObjects;

public sealed record Description
{
    public string Value { get; }
    // TODO: ZMIENIĆ WARUNKI DLA Description
    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidNameException(value);
        }

        /*if (value.Length is > 1000 or < 50)
        {
            throw new InvalidNameException(value);
        }*/

        Value = value;
    }

    public static implicit operator Description(string value) => new Description(value);

    public static implicit operator string(Description value) => value?.Value;

    public override string ToString() => Value;
}