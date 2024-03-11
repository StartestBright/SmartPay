using SmartPay.Server.Services.Interfaces;
using System;

namespace SmartPay.Server.Services
{
	public class PayPeriodFormatter : IPayPeriodFormatter
	{
		public string FormatPayPeriod(int year, int month)
		{
			var firstDay = new DateTime(year, month, 1).ToString("dd MMMM");
			var lastDay = new DateTime(year, month, DateTime.DaysInMonth(year, month)).ToString("dd MMMM");
			return $"{firstDay} – {lastDay}";

		}
	}
}
