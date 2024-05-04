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
        public int? LecturerId { get; set;}
        public Lecturer? lecturer { get; set;}=null!;
        public ICollection<CourseRegister>CourseRegisters { get; set;} = new List<CourseRegister>();
    }
}