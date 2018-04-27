using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RateMyClasses.Models
{
    public class Moderators
    {
        
        public Int64 id { get; set; }

        public string name { get; set; }

        public string hash { get; set; }

        public Moderators(string name, string hash) 
        {
            this.name = name;
            this.hash = hash;
        }
        
        public Moderators() {
            
        }

        // public void SaveToDatabase()
        // {
        //     using (var context = new ModeratorsContext(new DbContextOptions<ModeratorsContext>()))
        //     {
        //         context.Moderators.Add(this);
        //         context.SaveChanges();
        //     }
        // }
    }
}
