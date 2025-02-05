namespace ucn_user_review_backend_v3.Model;

public class Schedule
{
    private readonly IDictionary<string, HashSet<Class>> _classes =
        new Dictionary<string, HashSet<Class>>();

    public void AddClass(string day,
        Class clazz)
    {
        if (_classes.TryGetValue(day, out var dayClasses))
        {
            dayClasses = _classes[day];
            dayClasses.Add(clazz);
            return;
        }
        dayClasses = [clazz];
        _classes[day] = dayClasses;
    }

    public IDictionary<string, HashSet<Class>> Get()
    {
        return _classes;
    }

    public static Schedule EmptySchedule()
    {
        return new Schedule();
    }
}

public class ScheduleView
{
    public IList<ScheduleDayView> Days { get; set; } = [];
}

public class ScheduleDayView
{
    public string Name { get; set; } = string.Empty;

    public IList<Class> Blocks { get; set; } = [];
    
}

public class Class
{
    public string Block { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}
