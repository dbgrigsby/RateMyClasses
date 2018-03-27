using Microsoft.EntityFrameworkCore;

namespace RateMyClasses.Models
{
    public class ReportContext: DbContext
    {
        public ReportContext (DbContextOptions<ReportContext> options)
            : base(options)
        {
        }
        
        public DbSet<RateMyClasses.Models.Report> Report { get; set; }

    }
}