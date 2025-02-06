using System.ComponentModel.DataAnnotations;

namespace ucn_user_review_backend_v3.Model;

public class User
{

    public int Id { get; set; } 

    public int ProfileId { get; set; }
    
    [MaxLength(100)] public required string Name { get; set; } = string.Empty;
    [MaxLength(100)] public required string Email { get; set; } = string.Empty;
    [MaxLength(100)] public required string City { get; set; } = string.Empty;
    [MaxLength(100)] public required string Country { get; set; } = string.Empty;
    [MaxLength(100)] public required string CareerName { get; set; } = string.Empty;
    [MaxLength(10)] public required string CareerCode { get; set; } = string.Empty;
    [MaxLength(1000)] public required string Courses { get; set; } = string.Empty;
    [MaxLength(15)] public required string UniversityType { get; set; } = string.Empty;

}

public class UserPreview
{

    public int Id { get; set; }
    [MaxLength(100)] public required string Name { get; set; }
    
    [MaxLength(100)] public required string Career { get; set; }
    
    [MaxLength(25)] public required string UniversityType { get; set; }
    
}

public class UserView
{

    public int Id { get; set; } = 0;

    public int ProfileId { get; set; } = 0;
    
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string CareerName { get; set; } = string.Empty;
    public string CareerCode { get; set; } = string.Empty;
    public string[] Courses { get; set; } = [];
    public string UniversityType { get; set; } = string.Empty;
    
}