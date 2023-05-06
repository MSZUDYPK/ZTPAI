namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidRoleException : Exception
{
    public string Role { get; }

    public InvalidRoleException(string role) : base($"Role: '{role}' is invalid.")
    {
        Role = role;
    }
}