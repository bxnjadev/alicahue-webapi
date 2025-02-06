using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Mapper.Types;

public class UserPreviewMapper : IObjectMapper<User, UserPreview>
{
    
    public UserPreview Map(User u)
    {
        return new UserPreview
        {
            Id = u.Id,
            Name = u.Name,
            Career = u.CareerName,
            UniversityType = u.UniversityType
        };
    }
    
}