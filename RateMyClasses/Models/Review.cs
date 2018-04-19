using System;
using System.ComponentModel.DataAnnotations;

namespace RateMyClasses.Models
{
    public class Review
    {

        public Int64 id { get; set; }
        
		[Required]
		public Int64 courseId { get; set; }

		[DataType(DataType.Text)]
		[StringLength(60, MinimumLength = 2)]
		[Required]
        public string professorName { get; set; }
        
		[StringLength(500, MinimumLength = 10)]
		[RegularExpression(@"^(?!.*(www|w w w|gmail|@)).*$", ErrorMessage = "This description contains spam. Please keep our website spam-free.")]


		public string description { get; set; }
        
		[DataType(DataType.Date)]
		[Required]
		public DateTime dateCreated { get; set; }
        public bool isHidden { get; set; }
        
		[Range(1, 10)]
		[Required]
		public int score { get; set; }

        public Review()
        {
        }
    }
}
