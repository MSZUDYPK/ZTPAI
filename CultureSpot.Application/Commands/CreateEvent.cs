using CultureSpot.Application.Shared;
namespace CultureSpot.Application.Commands;

public record CreateEvent(
        string Name,
        string Description,
        int Type,
        decimal Price,
        int Capacity) : CommandBase<Guid>;