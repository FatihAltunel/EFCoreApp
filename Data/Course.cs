using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Course{
        [Key]
        public int CourseId { get; set;}
        public string CourseName { get; set;} = "";
    }
}