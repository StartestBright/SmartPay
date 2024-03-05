using System.ComponentModel.DataAnnotations;

namespace SmartPay.Server.Dto
{
	public class PayslipDetailsDto 
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z]+ [a-zA-Z]+$", ErrorMessage = "Name must be a full name with a space between first and last name.")]
		public string Name { get; set; } 

		[Range(1, int.MaxValue, ErrorMessage = "Year must be a positive number.")]
		public int Year { get; set; }

		[Range(1, 12, ErrorMessage = "Month must be between 1 and 12.")]
		public int Month { get; set; }

		public string PayPeriod {  get; set; }

		public decimal GrossIncome { get; set; }
		public decimal IncomeTax { get; set; }
		public decimal NetIncome { get; set; }
		public decimal Super { get; set; }
	}
}
