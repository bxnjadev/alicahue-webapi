using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Service;
using ucn_user_review_backend_v3.Util;

namespace ucn_user_review_backend_v3.Schedule;

public class DefaultCourseManager(
    IBaseService<User> userService,
    IBaseService<Course> courseService
) : ICourseManager
{
    private const string Separator = ";";

    public async Task<IList<Course>> FindCoursesFromUser(int userId)
    {
        var codes = await FindCoursesIdFromUser(userId);
        return await courseService.
            SearchAll(course => codes.Contains(course.Nrc));
    }

    public async Task<IList<int>> FindCoursesIdFromUser(int userId)
    {
        var user = await userService.FindByIdAsync(userId);
        if (user == null)
        {
            return Collections.EmptyList<int>();
        }

        var coursesName = user.Courses.Split(Separator)
            .ToList();
        var codes = new List<int>();
        
        foreach (var courseName in coursesName)
        {
            var nrcAndSection = ExtractMetadataFromCourseName(courseName);
            if (nrcAndSection != null)
            {
                codes.Add(nrcAndSection.Item1);
            }
        }

        return codes;
    }

    public Tuple<int, string>? ExtractMetadataFromCourseName(string name)
    {
        if (name.Contains('('))
        {
            var nrcAndSection = name.Split('(')[1];
            nrcAndSection = nrcAndSection.Remove( nrcAndSection.Length - 1);
            var nrcAndSectionPart = nrcAndSection.Split("-");

            var nrc = Int32.Parse(nrcAndSectionPart[0]);
            var section = nrcAndSectionPart[1];
            return new Tuple<int, string>(nrc, section);
        }

        return null;
    }

    public bool UserBelongCourse(int userId, int nrc)
    {
        throw new NotImplementedException();
    }

    public async Task<Course?> FindCourseByNrc(int nrc)
    {
        var courses = await courseService.SearchAll(
            course => course.Nrc == nrc
        );
        return courses.First();
    }

    public async Task<Model.Schedule?> FindSchedule(int userId)
    {
        var schedule = new Model.Schedule();
        var courses = await FindCoursesFromUser(userId);
        foreach (var course in courses)
        {
            foreach (var courseBlock in course.Blocks)
            {
                schedule.AddClass(courseBlock.Day, 
                    new Class
                    {
                        Block = courseBlock.BlockValue,
                        Name= course.Name
                    });
            }
        }

        return schedule;
    }

    public Task<IDictionary<string, string[]>> FindCommonSchedule(ISet<int> ids)
    {
        throw new NotImplementedException();
    }
    
}