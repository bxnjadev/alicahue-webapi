using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Mapper.Types;

public class ProfessorMapper : IObjectMapper<Professor, ProfessorView>
{
    public ProfessorView Map(Professor entity)
    {
        return new ProfessorView
        {
            Name = entity.Name,
            Id = entity.Id
        };
    }
}