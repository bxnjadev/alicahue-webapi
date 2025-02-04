using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Mapper;

public class UserMapper : IObjectMapper<User, 
    UserView>
{

    private const string SeparatorCourses = ";";

    public UserView Map(User user)
    {

        var courses = user.Courses
            .Split(SeparatorCourses);

        return new UserView
        {
            Id = user.Id,
            ProfileId = user.ProfileId,
            Name = user.Name,
            City = user.City,
            UniversityType = user.UniversityType,
            CareerCode = user.CareerCode,
            CareerName = user.CareerName,
            Email = user.Email,
            Courses = courses
        };

    }
    
}