using CultureSpot.Core.Users.Exceptions;
using System.Text.RegularExpressions;

namespace CultureSpot.Core.Users.ValueObjects
{
    public sealed partial record PhoneNumber
    {
        private static readonly Regex Regex = MyRegex();

        [GeneratedRegex("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", RegexOptions.Compiled)]
        private static partial Regex MyRegex();

        public string Value { get; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidPhoneNumberException(value);
            }

            /*if (!Regex.IsMatch(value))
            {
                throw new InvalidPhoneNumberException(value);
            }*/

            Value = value;
        }

        public static implicit operator PhoneNumber(string value) => new(value);

        public static implicit operator string(PhoneNumber value) => value?.Value;

        public override string ToString() => Value;
    }
}
