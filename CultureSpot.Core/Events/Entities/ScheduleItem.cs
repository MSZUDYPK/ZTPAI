using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;

namespace CultureSpot.Core.Events.Entities;


public class ScheduleItem
{
    public Guid ScheduleItemId { get; private set; }
    public ScheduleId ScheduleId { get; private set; }
    public Name Name { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public Description Description { get; private set; }

    private ScheduleItem()
    {
    }

    public ScheduleItem(Guid scheduleItemId, ScheduleId scheduleId, DateOnly date, TimeOnly startTime, TimeOnly endTime, Description description)
    {
        ScheduleItemId = scheduleItemId;
        ScheduleId = scheduleId;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        Description = description;
    }
}
