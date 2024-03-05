using SmartPay.Server.Models;
using SmartPay.Server.Services.Interfaces;

namespace SmartPay.Server.Services
{
	public class IncomeTaxCalculator : IIncomeTaxCalculator
	{
		private readonly List<TaxBracket> _taxBrackets;
		public IncomeTaxCalculator(List<TaxBracket> taxBrackets)
		{
			_taxBrackets = taxBrackets;
		}
		public decimal CalculateIncomeTax(decimal annualSalary)
		{
			decimal incomeTax = 0;
			if (annualSalary <= 0) return incomeTax;
			foreach (var bracket in _taxBrackets)
			{
				if (annualSalary > bracket.LowerBound)
				{
					var taxableIncomeInBracket = Math.Min(annualSalary, bracket.UpperBound) - bracket.LowerBound;
					incomeTax += taxableIncomeInBracket * bracket.TaxRate;
					if (annualSalary <= bracket.UpperBound) break;
				}
			}
			
			//decimal monthlyTax = incomeTax / 12;
			//return Math.Round(monthlyTax, 2, MidpointRounding.AwayFromZero); // rounding once to minimize the floating-point error
			return Math.Round(incomeTax / 12, 2, MidpointRounding.AwayFromZero);
		}
	}
}
