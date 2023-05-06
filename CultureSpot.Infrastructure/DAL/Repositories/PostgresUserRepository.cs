using Microsoft.EntityFrameworkCore;
using CultureSpot.Core.Users.Entities;
using CultureSpot.Core.Users.Repositories;
using CultureSpot.Core.Users.ValueObjects;
using CultureSpot.Infrastructure.DAL.Context;

namespace CultureSpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public PostgresUserRepository(CultureSpotDbContext dbContext)
    {
        _users = dbContext.Users;
    }

    public Task<User> GetByIdAsync(UserId id)
        => _users.SingleOrDefaultAsync(x => x.Id == id);

    public Task<User> GetByEmailAsync(Email email)
        => _users.SingleOrDefaultAsync(x => x.Email == email);

    public Task<User> GetByUsernameAsync(Username username)
        => _users.SingleOrDefaultAsync(x => x.Username == username);

    public async Task AddAsync(User user)
        => await _users.AddAsync(user);
}
