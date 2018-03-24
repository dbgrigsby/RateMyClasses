using Microsoft.EntityFrameworkCore;

namespace RateMyClasses.Models
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        {
        }

        public DbSet<RateMyClasses.Models.Course> Course { get; set; }
    }
}