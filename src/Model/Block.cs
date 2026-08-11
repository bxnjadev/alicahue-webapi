using System.ComponentModel.DataAnnotations;

namespace ucn_user_review_backend_v3.Model;

public class Block
{

    public int Id { get; set; } = 0;
    
    [MaxLength(30)] public string Day { get; set; } = string.Empty;

    [MaxLength(30)] public string Room { get; set; } = string.Empty;
    
    [MaxLength(2)] public string BlockValue { get; set; } = string.Empty;
    
    public int IdCourse { get; set; }
    public Course Course { get; set; } 

}

public class BlockView
{
    public int Id { get; set; } = 0;
    public string Day { get; set; } = string.Empty;

    public string Room { get; set; } = string.Empty;
    public string BlockValue { get; set; } = string.Empty;
    
}