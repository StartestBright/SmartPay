using SmartPay.Server.Services.Interfaces;

namespace SmartPay.Server.Services
{
	public class SuperCalculator : ISuperCalculator
	{
		public decimal CalculateSuper(decimal grossIncome, decimal superRate)
		{
			return grossIncome * superRate;
		}
	}
}
