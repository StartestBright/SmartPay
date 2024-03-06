using SmartPay.Server.Services.Interfaces;

namespace SmartPay.Server.Services
{
	public class SuperCalculator : ISuperCalculator
	{
		public decimal CalculateSuper(decimal grossIncome, decimal superRate)
		{
			return Math.Round(grossIncome * (superRate/100),2,MidpointRounding.AwayFromZero); // Superrate in %
		}
	}
}
