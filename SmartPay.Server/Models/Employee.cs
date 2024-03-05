namespace SmartPay.Server.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public decimal AnnualSalary { get; set; }
		public decimal SuperRate { get; set; }

		public string FullName => $"{FirstName} {LastName}";
	}
}
