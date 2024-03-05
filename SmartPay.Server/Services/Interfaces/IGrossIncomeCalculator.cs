namespace SmartPay.Server.Services.Interfaces
{
	public interface IGrossIncomeCalculator
	{
		public decimal CalculateGrossIncome(decimal annualSalary);
	}
}
