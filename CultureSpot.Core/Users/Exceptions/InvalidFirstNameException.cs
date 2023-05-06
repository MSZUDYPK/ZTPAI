namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidFirstNameException : Exception
{
    public string FirstName { get; }

    public InvalidFirstNameException(string firstName) : base($"First name: '{firstName}' is invalid.")
    {
        FirstName = firstName;
    }
}