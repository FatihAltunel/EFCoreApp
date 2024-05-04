using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Lecturer{
        [Key]
        [Display(Name = "Lecturer ID")]
        public int LecturerId { get; set;}
        [Display(Name = "Lecturer Name")]
        [Required]
        public string LecturerName { get; set;} = "";
        [EmailAddress]
        [Required]
        [Display(Name ="Email Address")]
        public string Email{ get; set;}="";
        [Required]
        [Phone]
        [Display(Name ="Phone Number")]
        public string PhoneNumber{ get; set;}="";
        [Display(Name ="Starting Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0: dd.MM.yyyy}", ApplyFormatInEditMode = false)]
        public DateTime startDate{ get; set;}
        public ICollection<Course>Courses { get; set;} = new List<Course>();
    }
}