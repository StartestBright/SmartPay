using SmartPay.Server.Services;
namespace SmartPay.Server.Tests.ServiceTests
{
	public class SuperCalculatorTests
	{
		[Theory]
		[InlineData(60050,9,450.38)]
		public void CalculateSuper_Returns_ExpectedResult(decimal grossIncome, decimal superRate,decimal expectedResult)
		{
			SuperCalculator superCalculator = new SuperCalculator();
			decimal result = superCalculator.CalculateSuper(grossIncome, superRate);
			Assert.Equal(expectedResult, Math.Round(result/12,2,MidpointRounding.AwayFromZero)); // Convert to monthly super

		}
	}
}
