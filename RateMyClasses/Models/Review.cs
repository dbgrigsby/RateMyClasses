using System;
namespace RateMyClasses.Models
{
    public class Review
    {

        public Int64 id { get; set; }
        public Int64 courseId { get; set; }
        public string professorName { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
        public bool isHidden { get; set; }
        public int score { get; set; }

        public Review()
        {
        }
    }
}
