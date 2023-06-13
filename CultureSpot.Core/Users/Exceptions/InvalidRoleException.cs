using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidRoleException : CustomException
{
    public string Role { get; }

    public InvalidRoleException(string role) : base($"Role: '{role}' is invalid.")
        => Role = role;
}