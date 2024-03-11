namespace SmartPay.Server.Models
{
	public class Employee
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public decimal AnnualSalary { get; set; }
		public decimal SuperRate { get; set; }

		public string FullName => $"{FirstName} {LastName}";

		public Employee(string firstName, string lastName, decimal annualSalary, decimal superRate)
		{
			Id = Guid.NewGuid();
			FirstName = firstName ;
			LastName = lastName ;
			AnnualSalary = annualSalary;
			SuperRate = superRate;
		}
	}

}
