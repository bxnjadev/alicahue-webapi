using System.ComponentModel.DataAnnotations;

namespace ucn_user_review_backend_v3.Model;

public class Block
{

    public int Id { get; set; } = 0;
    
    [MaxLength(30)]
    public string Day { get; set; } = string.Empty;
    
    [MaxLength(1)]
    public string BlockValue { get; set; } = string.Empty;

    public int IdCourse { get; set; } = 0;

    public Course Course { get; set; } = null;

}

public class BlockView
{
    public int Id { get; set; } = 0;
    public string Day { get; set; } = string.Empty;
    public string BlockValue { get; set; } = string.Empty;
    
}