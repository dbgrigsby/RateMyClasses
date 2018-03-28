using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RateMyClasses.Models
{
    public class ReportContext: DbContext
    {
        public ReportContext (DbContextOptions<ReportContext> options)
            : base(options)
        {
        }
        
        public DbSet<RateMyClasses.Models.Report> Report { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			if (!optionsBuilder.IsConfigured) {
				var connectionString = ("Data Source=RateMyClasses.db");
				optionsBuilder.UseSqlite(connectionString);
			}
		}
    }
}