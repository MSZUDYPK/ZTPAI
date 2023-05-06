namespace CultureSpot.Core.Events.Exceptions;

public sealed class InvalidPriceException : ArgumentOutOfRangeException
{
    public decimal Price { get; }

    public InvalidPriceException(decimal price) : base($"Price: '{price}' is invalid.")
    {
        Price = price;
    }
}