using CultureSpot.Core.Events.ValueObjects;

namespace CultureSpot.Core.Events.Entities;

public class Schedule
{
    public ScheduleId ScheduleId { get; private set; }
    public ICollection<ScheduleItem> ScheduleItems { get; private set; }

    private Schedule()
    {
        ScheduleItems = new List<ScheduleItem>();
    }

    public Schedule(ScheduleId scheduleId)
    {
        ScheduleId = scheduleId;
        ScheduleItems = new List<ScheduleItem>();
    }

    public Schedule(ScheduleId scheduleId, ICollection<ScheduleItem> scheduleItems)
    {
        ScheduleId = scheduleId;
        ScheduleItems = scheduleItems;
    }

    public void AddScheduleItem(ScheduleItem scheduleItem)
    {
        ScheduleItems.Add(scheduleItem);
    }
}