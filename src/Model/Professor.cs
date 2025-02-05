using System.ComponentModel.DataAnnotations;

namespace ucn_user_review_backend_v3.Model;

public class Professor
{

    public int Id { get; set; } = 0;
    
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    public int IdCourse { get; set; } = 0;
    public Course Course { get; set; } = null;

}

public class ProfessorView
{

    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;

}