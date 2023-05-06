using MediatR;
using Microsoft.EntityFrameworkCore;
using CultureSpot.Application.DTO;
using CultureSpot.Application.Queries;
using CultureSpot.Core.Users.ValueObjects;
using CultureSpot.Infrastructure.DAL.Context;

namespace CultureSpot.Infrastructure.DAL.Handlers;

internal sealed class GetUserHandler : IRequestHandler<GetUser, UserDto>
{
    private readonly CultureSpotDbContext _dbContext;

    public GetUserHandler(CultureSpotDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<UserDto> Handle(GetUser query, CancellationToken cancellationToken)
    {
        var userId = new UserId(query.UserId);
        var user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == userId, cancellationToken: cancellationToken);

        return user?.AsDto();
    }
}