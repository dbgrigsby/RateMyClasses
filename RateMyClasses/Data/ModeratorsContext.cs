using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RateMyClasses.Models;

    public class ModeratorsContext : DbContext
    {
        public ModeratorsContext (DbContextOptions<ModeratorsContext> options)
            : base(options)
        {
        }

        public DbSet<RateMyClasses.Models.Moderators> Moderators { get; set; }
    }
