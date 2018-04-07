using System;
using System.ComponentModel.DataAnnotations;

namespace RateMyClasses.Models
{
	public class Student
	{
		public Int64 id { get; set; }

		[StringLength(60, MinimumLength = 2)]
		[DataType(DataType.Text)]
		[Required]
		public string firstName { get; set; }

		[StringLength(60, MinimumLength = 2)]
		[DataType(DataType.Text)]
		[Required]
		public string lastName { get; set; }

		[DataType(DataType.Text)]
		[StringLength(60, MinimumLength = 2)]
		[Required]
		public string studentStatus { get; set; }

		[StringLength(30, MinimumLength = 6)]
		[Required]
		public string userName { get; set; }

		public bool isModerator { get; set; }

		public Student()
		{
		}
	}
}
