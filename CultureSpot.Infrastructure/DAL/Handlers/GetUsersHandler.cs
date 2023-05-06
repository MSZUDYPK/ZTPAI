using MediatR;
using Microsoft.EntityFrameworkCore;
using CultureSpot.Application.DTO;
using CultureSpot.Application.Queries;
using CultureSpot.Infrastructure.DAL.Context;

namespace CultureSpot.Infrastructure.DAL.Handlers;

internal sealed class GetUsersHandler : IRequestHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly CultureSpotDbContext _dbContext;

    public GetUsersHandler(CultureSpotDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<UserDto>> Handle(GetUsers query, CancellationToken cancellationToken)
        => await _dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync(cancellationToken: cancellationToken);
}