namespace SmartPay.Server.Services.Interfaces
{
	public interface IIncomeTaxCalculator
	{
		public decimal CalculateIncomeTax(decimal annualSalary);
	}
}
