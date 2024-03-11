namespace SmartPay.Server.Services.Interfaces
{
	public interface IPayPeriodFormatter
	{
		public string FormatPayPeriod(int year, int month);
	}
}
