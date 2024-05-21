namespace CandidateManagementSystem.Domain.Entities.Candidates;

public class TimeSlot : ValueObject
{
    public DateTime Date { get; }
    public TimeSpan StartTime { get; }
    public TimeSpan EndTime { get; }

    public TimeSlot(DateTime date, TimeSpan startTime, TimeSpan endTime)
    {
        if (startTime >= endTime)
        {
            throw new ArgumentException("Start time must be before end time");
        }

        Date = date;
        StartTime = startTime;
        EndTime = endTime;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
        yield return StartTime;
        yield return EndTime;
    }

    public override bool Equals(object? obj)
    {
        if (obj is TimeSlot other)
        {
            return Date == other.Date && StartTime == other.StartTime && EndTime == other.EndTime;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Date, StartTime, EndTime);
    }

    public static TimeSlot Create(DateTime date, TimeSpan startTime, TimeSpan endTime)
    {
        return new TimeSlot(date, startTime, endTime);
    }
}
