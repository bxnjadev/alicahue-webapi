using System.ComponentModel.DataAnnotations;

namespace ucn_user_review_backend_v3.Model;

public class User
{

    public int Id { get; set; } = 0;

    public int ProfileId { get; set; } = 0;
    
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string CareerName { get; set; } = string.Empty;
    public string CareerCode { get; set; } = string.Empty;
    public string Courses { get; set; } = string.Empty;
    public string UniversityType { get; set; } = string.Empty;

}

public class UserPreview
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Career { get; set; }
    
    public string UniversityType { get; set; }
    
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