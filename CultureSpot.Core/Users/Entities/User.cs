using CultureSpot.Core.Users.ValueObjects;

namespace CultureSpot.Core.Users.Entities;

public class User
{
    public UserId Id { get; private set; }
    public Username Username { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Role Role { get; private set; }

    private User()
    {
    }

    public User(UserId id, Username username, Email email, Password password, FirstName firstName, LastName lastName, PhoneNumber phoneNumber, Role role)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Role = role;
    }
}