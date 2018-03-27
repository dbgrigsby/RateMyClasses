using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RateMyClasses.Models
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        {
        }

        public DbSet<RateMyClasses.Models.Course> Course { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ("Data Source=RateMyClasses.db");
                optionsBuilder.UseSqlite(connectionString);
            }
        }
    }
}