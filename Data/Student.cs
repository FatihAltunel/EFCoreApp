using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Student{
        [Key]
        public int StudentId { get; set;}
        [Required]
        public string StudentName { get; set;} = "";
        [Required]
        [EmailAddress]
        public string Email { get; set;} = "";
        [Required]
        [Phone]
        public string PhoneNumber { get; set;} = "";
    }
}