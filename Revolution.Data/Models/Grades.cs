using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Revolution.Data.Models

{
    public class Grades
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long StudentId { get; set; }
        
        public Student Student { get; set; }
        
        public long SubjectId { get; set; }
        
        public Subject Subject { get; set; }
        
        public long Grade { get; set; }

        public string Date { get; set; } 
        
    }
}