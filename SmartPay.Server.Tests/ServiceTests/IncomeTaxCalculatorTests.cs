using SmartPay.Server.Services;
using SmartPay.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPay.Server.Tests.ServiceTests
{
	public class IncomeTaxCalculatorTests
	{
		[Theory]
		[InlineData(0, 0)] // No income, no tax
		[InlineData(60050, 919.58)] // Annual salary that spans first, second, and the third
		[InlineData(120000, 2543.33)] // Annual salary that spans the first, second, third, fourth 

		public void CalculateIncomeTax_ReturnsExpectedTax(decimal annualSalary, decimal expectedTax) {

			// Arrange
			var taxBrackets = new List<TaxBracket>
			{
				new TaxBracket { LowerBound = 0, UpperBound = 14000, TaxRate = 0.105m },
				new TaxBracket { LowerBound = 14000, UpperBound = 48000, TaxRate = 0.175m },
				new TaxBracket { LowerBound = 48000, UpperBound = 70000, TaxRate = 0.30m },
				new TaxBracket { LowerBound = 70000, UpperBound = 180000, TaxRate = 0.33m },
				new TaxBracket { LowerBound = 180000, UpperBound = 999999999, TaxRate = 0.39m }
			};


			var calculator = new IncomeTaxCalculator(taxBrackets);

			// Act
			var tax = calculator.CalculateIncomeTax(annualSalary);

			// Assert
			Assert.Equal(expectedTax, tax);
		}
	}
}
