using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Schedule;

public interface ICourseManager
{
 
    /**
     * Find all courses associated from a user
     * using the user id this retrieve a collection
     * with all courses
     * 
     */
    
    Task<IList<Course>> FindCoursesFromUser(int userId);

    /**
     * Find all courses id asocciated from a user
     * using the user ¿id this retrieve a colection
     * with all courses
     * 
     */
    Task<IList<int>> FindCoursesIdFromUser(int userId);
    
    /**
     * Obtain the nrc and section from a title course, the title courses are for a example
     * Name course = [Int. al Desarrollo Web/Móvil (22727-C1)]
     * The NRC Obtained will be NRC = 22727, Section = C1
     */
    
    Tuple<int, string>? ExtractMetadataFromCourseName(string courseName);
    
    /**
     * Check if the user belong to the course
     */
    
    Task<bool> UserBelongCourse(int userId,
     int nrc);

    /**
     * Search a course by a NRC given
     * the NRC is a identifier for courses
     * in the university catholic of the nort
     */
    
    Task<Course?> FindCourseByNrc(int nrc);
    
    /**
     * Find the schedule user from id 
     */
    
    Task<Model.Schedule?> FindSchedule(int userId);

    /**
      Match hours free in common between a set users
     */
    
    Task<IDictionary<string, IList<string>>> MatchSchedule(ISet<int> ids);

}