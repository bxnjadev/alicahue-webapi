using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Mapper.Types;

public class CourseMapper(IObjectMapper<Professor, ProfessorView> professorMapper,
    IObjectMapper<Block, BlockView> blockMapper) : IObjectMapper<Course, 
    CourseView>
{
    
    public CourseView Map(Course course)
    {
        
        var blocks = course.Blocks;
        var professors = course.Professors;

        var blocksView = blockMapper.Map(blocks);
        var professorsView = professorMapper.Map(professors);
        
        return new CourseView
        {
            Id = course.Id,
            Description = course.Description,
            UniversityType = course.UniversityType,
            Section = course.Section,
            CourseNumber = course.CourseNumber,
            Nrc = course.Nrc,
            Period = course.Period,
            Hours = course.Hours,
            Name = course.Name,
            Blocks = blocksView,
            Professors = professorsView
        };
    }
    
}