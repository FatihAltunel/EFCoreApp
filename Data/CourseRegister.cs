using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class CourseRegister{
        [Key]
        public int CourseRegisterId { get; set;}
        public int  StudentId { get; set;}
        public int CourseId{ get; set;} 
        public DateTime RegsiterDate{ get; set;}
    }
}