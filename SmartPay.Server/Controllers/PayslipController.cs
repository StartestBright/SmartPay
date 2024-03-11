using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartPay.Server.Dto;
using SmartPay.Server.Models;
using SmartPay.Server.Services.Interfaces;

namespace SmartPay.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PaySlipController : Controller
	{
		private readonly IPayslipService _paySlipService;
		private readonly IMapper _mapper;
		private readonly IGrossIncomeCalculator _grossIncomeCalculator;
		private readonly IIncomeTaxCalculator _incomeTaxCalculator;
		private readonly ISuperCalculator _superCalculator;
		public PaySlipController(IPayslipService paySlipService,/*IGrossIncomeCalculator grossIncomeCalculator,IIncomeTaxCalculator incomeTaxCalculator, ISuperCalculator superCalculator */ IMapper mapper) { 
			_paySlipService = paySlipService;					
			_mapper = mapper;
			//_grossIncomeCalculator = grossIncomeCalculator;
			//_incomeTaxCalculator = incomeTaxCalculator;
			//_superCalculator	= superCalculator;
		}

		[HttpPost]
		public ActionResult<PayslipDetailsDto> GeneratePayslip([FromBody] PayslipRequestDto requestDto)
		{
			if (requestDto == null)
			{
				return BadRequest("Employee details are required.");
			}
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var payslipDetails = _mapper.Map<PayslipDetails>(requestDto);
				_paySlipService.CalculatePayslip(payslipDetails);
				var payslipDetailsDto = _mapper.Map<PayslipDetailsDto>(payslipDetails);

				//var payslipDetails = _mapper.Map<PayslipDetailsDto>(requestDto); 
				//payslipDetails.GrossIncome = CalculateGrossIncome(requestDto.AnnualSalary);
				//payslipDetails.IncomeTax = CalculateIncomeTax(requestDto.AnnualSalary);
				//payslipDetails.NetIncome = payslipDetails.GrossIncome - payslipDetails.IncomeTax;
				//payslipDetails.Super =CalculateSuper(payslipDetails.GrossIncome, requestDto.SuperRate);
				//payslipDetails.PayPeriod = FormatPayPeriod(requestDto.Year, requestDto.Month);
				return Ok(payslipDetailsDto);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "An error occurred while generating the payslip. Please try again later.");
			}
		}
		//private string FormatPayPeriod(int year, int month)
		//{
		//	var firstDay = new DateTime(year, month, 1).ToString("dd MMMM");
		//	var lastDay = new DateTime(year, month, DateTime.DaysInMonth(year, month)).ToString("dd MMMM");
		//	return $"{firstDay} – {lastDay}";
		//}

		//private decimal CalculateGrossIncome(decimal salary)
		//{
		//	return _grossIncomeCalculator.CalculateGrossIncome(salary);
		//}
		//private decimal CalculateIncomeTax(decimal salary)
		//{
		//	return _incomeTaxCalculator.CalculateIncomeTax(salary);
		//}
		//private decimal CalculateSuper(decimal grossIncome, decimal superRate)
		//{
		//	return _superCalculator.CalculateSuper(grossIncome, superRate);
		//}

	}
}
