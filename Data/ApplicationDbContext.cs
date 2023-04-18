using Microsoft.EntityFrameworkCore;
using StudentRecord.Models;

namespace StudentRecord.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentImage> StudentImages { get; set; }
    }
}
