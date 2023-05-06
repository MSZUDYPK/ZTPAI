namespace CultureSpot.Core.Shared.Exceptions;

public sealed class InvalidEntityIdException : Exception
{
    public object Id { get; }

    public InvalidEntityIdException(object id) : base($"Cannot set: {id} as entity identifier.")
        => Id = id;
}