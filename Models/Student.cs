using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecord.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        public string Address { get; set; } = string.Empty;
        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }
        public string Bio { get; set; }

    }
}
