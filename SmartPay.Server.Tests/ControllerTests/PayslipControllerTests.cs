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
		private readonly PaySlipController _controller;

		public PayslipControllerTests()
		{
			_controller = new PaySlipController(_paySlipService.Object, _mapper.Object);
		}

		[Fact]
		public async Task GeneratePayslip_ReturnOkResult_WithValidRequest()
		{
			// Arrange
			PayslipRequestDto requestDto = new PayslipRequestDto {FirstName="John",LastName="Smith", AnnualSalary = 60050, SuperRate = 9.0M, Month = 3, Year = 2024 };
			PayslipDetails payslipDetails = new PayslipDetails { Employee = new Employee("John", "Smith", 60050, 9.0M), Year = 2023, Month = 3, PayPeriod = "01 March - 31 March", GrossIncome = 5004.17M, IncomeTax = 919.58M,NetIncome = 4084.59M,Super=450.38M };
			PayslipDetailsDto responseDto = new PayslipDetailsDto {Name="John Smith", GrossIncome = 5004.17M, IncomeTax = 919.58M, NetIncome = 4084.59M, Super = 450.38M, PayPeriod = "01 March - 31 March" };

			_mapper.Setup(m => m.Map<PayslipDetails>(It.IsAny<PayslipRequestDto>())).Returns(payslipDetails);
			_mapper.Setup(m => m.Map<PayslipDetailsDto>(It.IsAny<PayslipDetails>())).Returns(responseDto);
			_paySlipService.Setup(x => x.CalculatePayslip(It.IsAny<PayslipDetails>())).Returns(payslipDetails);

			// Act
			var result = _controller.GeneratePayslip(requestDto);

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
