namespace SmartPay.Server.Services.Interfaces
{
	public interface ISuperCalculator
	{
		public decimal CalculateSuper(decimal grossIncome, decimal superRate);
	}
}
