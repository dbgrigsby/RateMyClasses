using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RateMyClasses.Models
{
    public class ModeratorsContext: DbContext
    {
        public ModeratorsContext (DbContextOptions<ModeratorsContext> options)
            : base(options)
        {
        }
        
        public DbSet<RateMyClasses.Models.Moderators> Moderators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                var connectionString = ("Data Source=RateMyClasses.db");
                optionsBuilder.UseSqlite(connectionString);
            }
        }
    }
}