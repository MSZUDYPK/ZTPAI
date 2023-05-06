using CultureSpot.Core.Shared.Time;
using CultureSpot.Core.Users.Entities;
using CultureSpot.Core.Users.Repositories;
using CultureSpot.Core.Users.ValueObjects;

namespace CultureSpot.Infrastructure.DAL.Repositories;

internal sealed class InMemoryUserRepository : IUserRepository
{

    private readonly List<User> _users;

    public InMemoryUserRepository()
    {
        _users = new List<User>
        {
           new User(Guid.Parse("00000000-0000-0000-0000-000000000001"), "username", "username@gmail.com", "stdpass", "Imie", "Nazwisko", "999999999", "admin"),
           new User(Guid.Parse("00000000-0000-0000-0000-000000000002"), "username2", "username2@gmail.com", "stdpass", "Imie2", "Nazwisko2", "888888888", "admin")
        };
    }

    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByEmailAsync(Email email)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(UserId id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUsernameAsync(Username username)
    {
        throw new NotImplementedException();
    }
}

