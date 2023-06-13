using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Application.Exceptions;

public sealed class EmailAlreadyInUseException : CustomException
{
    public string Email { get; }

    public EmailAlreadyInUseException(string email) : base($"Email: '{email}' is already in use.")
        => Email = email;
}