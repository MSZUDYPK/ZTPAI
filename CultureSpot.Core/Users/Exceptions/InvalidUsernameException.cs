using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidUsernameException : CustomException
{
    public string Username { get; }

    public InvalidUsernameException(string username) : base($"Username: '{username}' is invalid.")
        => Username = username;
}