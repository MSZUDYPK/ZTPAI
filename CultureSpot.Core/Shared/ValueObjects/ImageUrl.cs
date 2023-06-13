using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Shared.ValueObjects;

public sealed record ImageUrl
{
    public string Value { get; }

    public ImageUrl(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidImageUrlException(value);
        }

        Value = value;
    }

    public static implicit operator ImageUrl(string value) => new(value);

    public static implicit operator string(ImageUrl value) => value?.Value;

    public override string ToString() => Value;
}