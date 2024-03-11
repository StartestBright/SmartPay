namespace SmartPay.Server.Models
{
	public class PayslipDetails
	{
		public int Id { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		public string PayPeriod {get; set;}

		public decimal GrossIncome { get; set; }
		public decimal IncomeTax { get; set; }
		public decimal NetIncome { get; set; }
		public decimal Super { get; set; }
		public Employee Employee { get; set; }

		// Derived property pulling from the Employee object
		public string Name => $"{Employee.FirstName} {Employee.LastName}";
	}
}
