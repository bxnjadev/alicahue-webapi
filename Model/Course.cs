using System.ComponentModel.DataAnnotations;

namespace ucn_user_review_backend_v3.Model;

public class Course
{

    public int Id { get; set; } 
    
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string Description { get; set; } = string.Empty;
    public int CourseNumber { get; set; } = 0;
    
    [MaxLength(50)]
    public string Section { get; set; } = string.Empty;
    public int Hours { get; set; } = 0;
    public int Nrc { get; set; } = 0;
    
    [MaxLength(50)]
    public string Period { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string UniversityType { get; set; } = string.Empty;

    public List<Block> Blocks { get; set; } = [];
    
    public List<Professor> Professors { get; set; } = [];


}

public class CourseView
{

    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CourseNumber { get; set; } = 0;
    public string Section { get; set; } = string.Empty;
    public int Hours { get; set; } = 0;
    public int Nrc { get; set; } = 0;
    public string Period { get; set; } = string.Empty;
    public string UniversityType { get; set; } = string.Empty;

    public ICollection<BlockView> Blocks { get; set; } = [];
    
    public ICollection<ProfessorView> Professors { get; set; } = [];

    
}