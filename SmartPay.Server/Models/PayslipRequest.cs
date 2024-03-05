namespace SmartPay.Server.Models
{
	public class PayslipRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public decimal AnnualSalary { get; set; }
		public decimal SuperRate { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }
	}
}
