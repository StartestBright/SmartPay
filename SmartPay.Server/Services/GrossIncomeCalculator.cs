using SmartPay.Server.Services.Interfaces;

namespace SmartPay.Server.Services
{
	public class GrossIncomeCalculator : IGrossIncomeCalculator
	{
		public decimal CalculateGrossIncome(decimal annualSalary)
		{
			if (annualSalary <= 0) return 0;
			return Math.Round(annualSalary / 12, 2, MidpointRounding.AwayFromZero);
		}
	}
}
