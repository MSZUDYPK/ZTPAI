namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}
