namespace SleepTrackerAPI.Model;

public class SleepData
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
