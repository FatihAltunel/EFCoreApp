using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Student{
        [Key]
        public int StudentId { get; set;}
        public string StudentName { get; set;} = "";
        [EmailAddress]
        public string Email { get; set;} = "";
        [Phone]
        public string PhoneNumber { get; set;} = "";
    }
}