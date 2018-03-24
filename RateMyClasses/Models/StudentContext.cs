using Microsoft.EntityFrameworkCore;

namespace RateMyClasses.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<RateMyClasses.Models.Student> Student { get; set; }
    }
}