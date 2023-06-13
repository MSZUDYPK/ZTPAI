using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidPasswordException : CustomException
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}
