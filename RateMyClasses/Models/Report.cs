using System;
using System.ComponentModel.DataAnnotations;

namespace RateMyClasses.Models
{
    public class Report
    {
        public Int64 id { get; set; }

		[Required]
        public Int64 reviewID { get; set; }
       
		[DataType(DataType.Text)]
		public string reportContent { get; set; }
        public bool isHandled { get; set; }
    }
}