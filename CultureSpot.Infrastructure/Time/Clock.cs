using CultureSpot.Core.Shared.Time;

namespace CultureSpot.Infrastructure.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}