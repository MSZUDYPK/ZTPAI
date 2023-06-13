using CultureSpot.Application.DTO;
using CultureSpot.Application.Queries;
using CultureSpot.Core.Events.Entities;
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
    {
        IQueryable<Event> query = _dbContext.Events.AsNoTracking();

        switch (request.OrderBy)
        {
            case OrderByOptions.Relevance:
                query = query.OrderByDescending(e => e.Date);
                break;
            case OrderByOptions.None:
                query = query.OrderByDescending(e => e.Price);
                break;
            default:
                break;
        }

        return await query.Select(x => x.AsDto()).ToListAsync(cancellationToken);
    }
}