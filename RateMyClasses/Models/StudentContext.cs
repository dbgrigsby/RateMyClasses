using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RateMyClasses.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<RateMyClasses.Models.Student> Student { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			if (!optionsBuilder.IsConfigured) {
				var connectionString = ("Data Source=RateMyClasses.db");
				optionsBuilder.UseSqlite(connectionString);
			}
		}
    }
}