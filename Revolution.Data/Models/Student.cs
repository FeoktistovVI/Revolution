using System.ComponentModel.DataAnnotations;

namespace Revolution.Data.Models;

public class Student
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string FatherName { get; set; } 
    public string DateOfBirth { get; set; } 
    public long Grade { get; set; }
    public long SchoolId { get; set; }

}