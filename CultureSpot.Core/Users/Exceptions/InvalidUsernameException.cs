namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidUsernameException : Exception
{
    public string Username { get; }

    public InvalidUsernameException(string username) : base($"Username: '{username}' is invalid.")
    {
        Username = username;
    }
}