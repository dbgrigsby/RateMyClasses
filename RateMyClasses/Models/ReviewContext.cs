using Microsoft.EntityFrameworkCore;

namespace RateMyClasses.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options)
            : base(options)
        {
        }

        public DbSet<RateMyClasses.Models.Review> Review { get; set; }
    }
}