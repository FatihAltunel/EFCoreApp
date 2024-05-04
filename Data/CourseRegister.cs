using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class CourseRegister{
        [Key]
        [Display(Name="Course Register ID")]
        public int CourseRegisterId { get; set;}
        [Display(Name="Student ID")]
        [Required(ErrorMessage = "The Student field is required.")]
        public int  StudentId { get; set;}
        public Student student{ get; set;}=null!;
        [Display(Name="Course ID")]
        [Required(ErrorMessage = "The Course field is required.")]
        public int CourseId{ get; set;} 
        public Course course{ get; set;}=null!;
        [Display(Name="Register Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0: dd.MM.yyyy}", ApplyFormatInEditMode = false)]
        public DateTime RegsiterDate{ get; set;}
    }
}