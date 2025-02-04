using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Mapper;

public class ScheduleMapper : IObjectMapper<Model.Schedule, ScheduleView>
{
    public ScheduleView Map(Model.Schedule entity)
    {
        var days = new List<ScheduleDayView>();
        foreach (var keyValuePair in entity.Get())
        {   
            days.Add(
                    new ScheduleDayView 
                    {
                        Name = keyValuePair.Key,
                        Blocks = keyValuePair.Value.ToList()
                    }
                );
        }

        return new ScheduleView
        {
            Days = days
        };
    }
}