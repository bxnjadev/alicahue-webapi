namespace ucn_user_review_backend_v3.Schedule;

public interface IScheduleHandler
{

    Task<Model.Schedule> GetSchedule(int userId);

    Model.Schedule GetSchedule(int userId,
        params string[] days);

}