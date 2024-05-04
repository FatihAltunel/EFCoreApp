using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Course{
        [Key]
        [Display(Name = "Course ID")]
        public int CourseId { get; set;}
        [Display(Name = "Course Name")]
        [Required]
        public string CourseName { get; set;} = "";
        public ICollection<CourseRegister>CourseRegisters { get; set;} = new List<CourseRegister>();
    }
}