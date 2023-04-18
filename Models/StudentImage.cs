using System.ComponentModel.DataAnnotations;

namespace StudentRecord.Models
{
    public class StudentImage
    {
        [Key]
        public int Sid { get; set; }
        public string Title { get; set; } = string.Empty;
        public byte[] ProfilePicture { get; set; }
    }
}
