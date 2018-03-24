using System;
namespace RateMyClasses.Models
{
    public class Student
    {
        public Int64 id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string studentStatus { get; set; }
        public string userName { get; set; }
        public bool isModerator { get; set; }
        public Student()
        {
        }
    }
}
