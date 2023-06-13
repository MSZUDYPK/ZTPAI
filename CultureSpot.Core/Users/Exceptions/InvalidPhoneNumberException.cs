using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidPhoneNumberException : CustomException
{
    public string PhoneNumber { get; }

    public InvalidPhoneNumberException(string phoneNumber) : base($"Phone number: '{phoneNumber}' is invalid.")
        => PhoneNumber = phoneNumber;
}