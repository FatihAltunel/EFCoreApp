using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Student{
        [Key]
        [Display(Name ="Student ID")]
        public int StudentId { get; set;}
        [Required]
        [Display(Name ="Student Name")]
        public string StudentName { get; set;} = "";
        [Required]
        [EmailAddress]
        [Display(Name ="Email Address")]
        public string Email { get; set;} = "";
        [Required]
        [Phone]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set;} = "";
    }
}