using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidFirstNameException : CustomException
{
    public string FirstName { get; }

    public InvalidFirstNameException(string firstName) : base($"First name: '{firstName}' is invalid.")
        => FirstName = firstName;
}