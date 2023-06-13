using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Application.Exceptions;

public class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {
    }
}
