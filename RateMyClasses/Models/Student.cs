using System;
namespace RateMyClasses.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public Student()
        {
        }
    }
}
