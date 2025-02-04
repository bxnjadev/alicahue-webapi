namespace ucn_user_review_backend_v3.Model;

public class Schedule
{
    public IDictionary<string, HashSet<BlockWithClass>> _scheduleMap { get; set; } =
        new Dictionary<string, HashSet<BlockWithClass>>();

    public void AddBlock(string day,
        BlockWithClass blockWithClass)
    {
        var blocks = new HashSet<BlockWithClass>();
        if (!_scheduleMap.ContainsKey(day))
        {
           blocks = new HashSet<BlockWithClass>();
           _scheduleMap[day] = blocks;
        }

        blocks = _scheduleMap[day];
        blocks.Add(blockWithClass);
    }

    public IDictionary<string, HashSet<BlockWithClass>> GetSchedule()
    {
        return _scheduleMap;
    }

    public static Schedule EmptySchedule()
    {
        return new Schedule();
    }
}

public class ScheduleView
{

    public IList<ScheduleViewDay> Days { get; set; }
    
}

public class ScheduleViewDay
{
    public string Name { get; set; } = string.Empty;

    public IList<BlockWithClass> Blocks { get; set; } = [];

}

public class BlockWithClass
{
    
    public string Name { get; set; }
    
    public string Class { get; set; }
    
}