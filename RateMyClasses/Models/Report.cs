using System;

namespace RateMyClasses.Models
{
    public class Report
    {
        public Int64 id { get; set; }
        public Int64 reviewID { get; set; }
        public string reportContent { get; set; }
        public bool isHandled { get; set; }
    }
}