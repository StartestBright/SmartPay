using AutoMapper;
using SmartPay.Server.Services.Interfaces;
using SmartPay.Server.Controllers;
using Moq;
using SmartPay.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using SmartPay.Server.Models;

namespace SmartPay.Server.Tests.ControllerTests
{
	public class PayslipControllerTests
	{
		private readonly Mock<IPayslipService> _paySlipService = new Mock<IPayslipService>();
		private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
		private readonly Mock<IGrossIncomeCalculator> _grossIncomeCalculator = new Mock<IGrossIncomeCalculator>();
		private readonly Mock<IIncomeTaxCalculator> _incomeTaxCalculator = new Mock<IIncomeTaxCalculator>();
		private readonly Mock<ISuperCalculator> _superCalculator = new Mock<ISuperCalculator>();
		private readonly PaySlipController _controller;

		public PayslipControllerTests()
		{
			_controller = new PaySlipController(_paySlipService.Object, _grossIncomeCalculator.Object, _incomeTaxCalculator.Object, _superCalculator.Object, _mapper.Object);
		}

		[Fact]
		public async Task GeneratePayslip_ReturnOkResult_WithValidRequest()
		{
			// Arrange
			PayslipRequestDto requestDto = new PayslipRequestDto {FirstName="John",LastName="Smith", AnnualSalary = 60050, SuperRate = 9.0M, Month = 3, Year = 2024 };
			PayslipDetailsDto responseDto = new PayslipDetailsDto {Name="John Smith", GrossIncome = 5004.17M, IncomeTax = 919.58M, NetIncome = 4084.59M, Super = 450.38M, PayPeriod = "01 March - 31 March" };

			_mapper.Setup(m => m.Map<PayslipDetailsDto>(requestDto)).Returns(responseDto);
			_grossIncomeCalculator.Setup(c => c.CalculateGrossIncome(requestDto.AnnualSalary)).Returns(responseDto.GrossIncome);
			_incomeTaxCalculator.Setup(c => c.CalculateIncomeTax(requestDto.AnnualSalary)).Returns(responseDto.IncomeTax);
			_superCalculator.Setup(c => c.CalculateSuper(It.IsAny<decimal>(), requestDto.SuperRate)).Returns(responseDto.Super);

			// Act
			var result =  _controller.GeneratePayslip(requestDto);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			var returnValue = Assert.IsType<PayslipDetailsDto>(okResult.Value);
			Assert.Equal(responseDto.GrossIncome, returnValue.GrossIncome);
			Assert.Equal(responseDto.IncomeTax, returnValue.IncomeTax);
			Assert.Equal(responseDto.NetIncome, returnValue.NetIncome);
			Assert.Equal(responseDto.Super, returnValue.Super);
			Assert.Equal(responseDto.PayPeriod, returnValue.PayPeriod);
		}
	}
}
