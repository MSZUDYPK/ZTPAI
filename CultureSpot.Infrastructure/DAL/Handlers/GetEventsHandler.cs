using CultureSpot.Application.DTO;
using CultureSpot.Application.Queries;
using CultureSpot.Infrastructure.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CultureSpot.Infrastructure.DAL.Handlers;

internal sealed class GetEventsHandler : IRequestHandler<GetEvents, IEnumerable<EventDto>>
{
    private readonly CultureSpotDbContext _dbContext;

    public GetEventsHandler(CultureSpotDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<EventDto>> Handle(GetEvents request, CancellationToken cancellationToken)
           => await _dbContext.Events
                    .AsNoTracking()
                    .Select(x => x.AsDto())
                    .ToListAsync(cancellationToken);
}