using System.ComponentModel.DataAnnotations;

namespace Revolution.Data;

public class Student
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FatherName { get; set; } = string.Empty;
    public string DateOfBirth { get; set; }
    public long Grade { get; set; }
    public long SchoolId { get; set; }
    public School School { get; set; }
    
}