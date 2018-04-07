using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RateMyClasses.Models
{
    public class Course
    {
		
        public Int64 id { get; set; }

		[StringLength(200, MinimumLength = 7)]
		[Required]
        public string name { get; set; }

        public string description { get; set; }

		[DataType(DataType.Url)]
        public string courseEvalLink { get; set; }

		[StringLength(10, MinimumLength = 3)]
		[Required]
        public string department { get; set; }

        public Course(string name, string department, string description) 
        {
            this.name = name;
            this.department = department;
            this.description = description;
            this.courseEvalLink = "";
        }
        
        public Course() 
        {
        }

        public void SaveToDatabase()
        {
            using (var context = new CourseContext(new DbContextOptions<CourseContext>()))
            {
                context.Course.Add(this);
                context.SaveChanges();
                //Console.WriteLine("Added " + this.name +  " to database!");
            }
        }
    }
}
