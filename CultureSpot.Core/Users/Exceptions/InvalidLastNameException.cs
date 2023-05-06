namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidLastNameException : Exception
{
    public string LastName { get; }

    public InvalidLastNameException(string lastName) : base($"Last name: '{lastName}' is invalid.")
    {
        LastName = lastName;
    }
}