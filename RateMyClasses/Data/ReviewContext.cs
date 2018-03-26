using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RateMyClasses.Models;

    public class ReviewContext : DbContext
    {
        public ReviewContext (DbContextOptions<ReviewContext> options)
            : base(options)
        {
        }

        public DbSet<RateMyClasses.Models.Review> Review { get; set; }
    }
