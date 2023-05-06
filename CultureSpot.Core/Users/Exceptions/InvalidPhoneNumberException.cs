namespace CultureSpot.Core.Users.Exceptions;

public sealed class InvalidPhoneNumberException : Exception
{
    public string PhoneNumber { get; }

    public InvalidPhoneNumberException(string phoneNumber) : base($"Phone number: '{phoneNumber}' is invalid.")
    {
        PhoneNumber = phoneNumber;
    }
}