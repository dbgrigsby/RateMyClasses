using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RateMyClasses.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options)
            : base(options)
        {
        }

        public DbSet<RateMyClasses.Models.Review> Review { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			if (!optionsBuilder.IsConfigured) {
				var connectionString = ("Data Source=RateMyClasses.db");
				optionsBuilder.UseSqlite(connectionString);
			}
		}
    }
}