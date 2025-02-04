using Microsoft.VisualBasic;
using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Service;

namespace ucn_user_review_backend_v3.Schedule;

public class ScheduleHandler(
    IBaseService<User> userService,
    IBaseService<Course> courseService) : IScheduleHandler
{
    
    private const char Separator = ';';
    
    public async Task<Model.Schedule> GetSchedule(int userId)
    {
        var schedule = Model.Schedule.EmptySchedule();
        var user = await userService.FindByIdAsync(userId);
        if (user == null)
        {
            return schedule;
        }

        var coursesName = user.Courses.Split(Separator)
            .ToList();
        
        var nrcs = new List<int>();
        foreach (var course in coursesName)
        {
            Console.WriteLine(course);
            if (course.Contains("("))
            {
                var nrcAndSection = course.Split("(")[1];
                nrcAndSection = nrcAndSection.Remove(nrcAndSection.Length - 1);
                var nrc = Int32.Parse(
                    nrcAndSection.Split("-")[0]
                );
                
                Console.WriteLine(nrc);
                nrcs.Add(nrc);
            }
        }

        var courses = await courseService.
            SearchAll(course => nrcs.Contains(course.Nrc));

        Console.WriteLine(courses.Count);
        
        foreach (var course in courses)
        {
            foreach (var courseBlock in course.Blocks)
            {
                schedule.AddBlock(courseBlock.Day, 
                    new BlockWithClass
                    {
                        Name = courseBlock.BlockValue,
                        Class = course.Name
                    });
            }
        }

        return schedule;
    }
    
}