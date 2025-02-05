using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Service;
using ucn_user_review_backend_v3.Util;

namespace ucn_user_review_backend_v3.Schedule;

public class DefaultCourseManager(
    IBaseRepository<User> userRepository,
    IBaseRepository<Course> courseRepository
) : ICourseManager
{
    private const string Separator = ";";
    private IList<string> _blocks = ["A", "B", "C", "D", "E", "F", "G"];
     
    public async Task<IList<Course>> FindCoursesFromUser(int userId)
    {
        var codes = await FindCoursesIdFromUser(userId);
        return await courseRepository.
            SearchAll(course => codes.Contains(course.Nrc));
    }

    public async Task<IList<int>> FindCoursesIdFromUser(int userId)
    {
        var user = await userRepository.FindByIdAsync(userId);
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

    public async Task<bool> UserBelongCourse(int userId, int nrc)
    {
        var courses = await FindCoursesIdFromUser(userId);
        return courses.Contains(nrc);
    }

    public async Task<Course?> FindCourseByNrc(int nrc)
    {
        var courses = await courseRepository.SearchAll(
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

    public async Task<IDictionary<string, IList<string>>> FindCommonSchedule(ISet<int> ids)
    {
        var commonScheduleMap = new Dictionary<string, IList<string>>
        {
            {"Lunes", _blocks.ToList()},
            {"Martes", _blocks.ToList()},
            {"Miercoles", _blocks.ToList()},
            {"Jueves", _blocks.ToList()},
            {"Viernes", _blocks.ToList()},
            {"Sabado", _blocks.ToList()},
            {"Domingo", _blocks.ToList()}
        };
        
        var users = new List<IList<Course>>();
        foreach (var id in ids)
        {
            var courses = await FindCoursesFromUser(id);
            users.Add(courses);
        }
        foreach (var courses in users)
        {
            foreach (var course in courses)
            {
                foreach (var courseBlock in course.Blocks)
                {
                    var blocksDay = commonScheduleMap[courseBlock.Day];
                    if (blocksDay.Contains(courseBlock.BlockValue))
                    {
                        blocksDay.Remove(courseBlock.BlockValue);
                    }
                }
            }
        }

        return commonScheduleMap;
    }
    
}