namespace CultureSpot.Application.Exceptions;

public sealed class UsernameAlreadyInUseException : Exception
{
    public string Username { get; }

    public UsernameAlreadyInUseException(string username) : base($"Username: '{username}' is already in use.")
    {
        Username = username;
    }
}
