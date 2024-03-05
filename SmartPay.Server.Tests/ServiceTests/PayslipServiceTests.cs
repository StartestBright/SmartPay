using SmartPay.Server.Services;
using Moq;
using SmartPay.Server.Models;
using SmartPay.Server.Services.Interfaces;

namespace SmartPay.Server.Tests.ServiceTests
{
	public class PayslipServiceTests
	{
		[Fact]
		public void CalculatePayslip_ReturnsCorrectPayslipDetails()
		{
			// AAA pattern
			// Arrange
			Mock<IIncomeTaxCalculator> mockIncomeTaxCalculator = new Mock<IIncomeTaxCalculator>();
			Mock<IGrossIncomeCalculator> mockGrossIncomeCalculator = new Mock<IGrossIncomeCalculator>();
			Mock<ISuperCalculator> mockSuperCalculator = new Mock<ISuperCalculator>();

			decimal annualSalary = 60000;
			decimal superRate = 0.09M; 
			int year = 2023;
			int month = 3; // March

			mockGrossIncomeCalculator.Setup(x => x.CalculateGrossIncome(annualSalary)).Returns(5000); 
			mockIncomeTaxCalculator.Setup(x => x.CalculateIncomeTax(annualSalary)).Returns(500);
			mockSuperCalculator.Setup(x => x.CalculateSuper(5000, superRate)).Returns(450);

			var service = new PayslipService(mockIncomeTaxCalculator.Object, mockGrossIncomeCalculator.Object, mockSuperCalculator.Object);

			var request = new PayslipDetails
			{
				Employee = new Employee
				{
					FirstName = "John",
					LastName = "Doe",
					AnnualSalary = annualSalary,
					SuperRate = superRate
				},
				Year = year,
				Month = month
			};

			// Act
			var result = service.CalculatePayslip(request);

			// Assert
			Assert.Equal(5000, result.GrossIncome); // Monthly gross income
			Assert.Equal(500, result.IncomeTax);
			Assert.Equal(4500, result.NetIncome); // GrossIncome - IncomeTax
			Assert.Equal(450, result.Super);
			Assert.Equal("John", result.Employee.FirstName);
			Assert.Equal("Doe", result.Employee.LastName);
		}

		[Theory]
		[InlineData(60050, 9, 5004.17, 919.58, 4084.59, 450.38)] // Example input: annualSalary, superRate, expectedGrossIncome, expectedIncomeTax, expectedNetIncome, expectedSuper
		public void CalculatePayslip_GivenVariousInputs_ReturnsExpectedResults(decimal annualSalary, decimal superRate, decimal expectedGrossIncome, decimal expectedIncomeTax, decimal expectedNetIncome, decimal expectedSuper)
		{
			// Using the Mock calculators to isolate the behavior of the PayslipService and ensure the tests are focused on the logic within itself
			// Arrange
			var mockIncomeTaxCalculator = new Mock<IIncomeTaxCalculator>();
			var mockGrossIncomeCalculator = new Mock<IGrossIncomeCalculator>();
			var mockSuperCalculator = new Mock<ISuperCalculator>();
			mockGrossIncomeCalculator.Setup(x => x.CalculateGrossIncome(annualSalary)).Returns(5004.17M);
			mockIncomeTaxCalculator.Setup(x => x.CalculateIncomeTax(annualSalary)).Returns(919.58M);
			mockSuperCalculator.Setup(x => x.CalculateSuper(5004.17M, superRate)).Returns(450.38M);

			var service = new PayslipService(mockIncomeTaxCalculator.Object, mockGrossIncomeCalculator.Object, mockSuperCalculator.Object);
			var request = new PayslipDetails
			{
				Employee = new Employee { AnnualSalary = annualSalary, SuperRate = superRate },
				Year = 2022,
				Month = 7
			};

			// Act
			var result = service.CalculatePayslip(request);

			// Assert
			Assert.Equal(expectedGrossIncome, result.GrossIncome);
			Assert.Equal(expectedIncomeTax, result.IncomeTax);
			Assert.Equal(expectedNetIncome, result.NetIncome);
			Assert.Equal(expectedSuper, result.Super);
		}
	}
}
