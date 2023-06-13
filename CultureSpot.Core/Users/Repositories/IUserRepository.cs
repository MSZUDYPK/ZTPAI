using CultureSpot.Core.Users.Entities;
using CultureSpot.Core.Users.ValueObjects;

namespace CultureSpot.Core.Users.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(UserId id);
    Task<User> GetByEmailAsync(Email email);
    Task AddAsync(User user);
}