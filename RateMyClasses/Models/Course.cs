using System;
namespace RateMyClasses.Models
{
    public class Course
    {

        public Int64 id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string courseEvalLink { get; set; }
        public string department { get; set; }
        public Course()
        {
        }
    }
}
