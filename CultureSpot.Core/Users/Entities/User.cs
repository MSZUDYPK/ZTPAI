using CultureSpot.Core.Users.ValueObjects;

namespace CultureSpot.Core.Users.Entities;

public class User
{
    public UserId Id { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private User()
    {
    }

    public User(UserId id, Email email, Password password, FirstName firstName, LastName lastName, PhoneNumber phoneNumber, Role role, DateTime createdAt)
    {
        Id = id;
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Role = role;
        CreatedAt = createdAt;
    }
}