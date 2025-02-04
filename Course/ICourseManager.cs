using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Schedule;

public interface ICourseManager
{

    /**
     * Find all courses associated from a user
     * using the user id this involve a collection
     * with all courses
     * 
     */
    
    
    
    Course[] FindCoursesFromUser(int userId);

    /**
     * Check if the user belong to the course
     */
    
    bool UserBelongCourse(int userId);
    
    /**
     * Find the schedule user from id 
     */
    
    Model.Schedule? FindSchedule(int userId);

    Model.Schedule? FindCommonSchedule(int userId);

}