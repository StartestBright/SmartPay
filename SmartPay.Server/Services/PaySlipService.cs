using SmartPay.Server.Dto;
using SmartPay.Server.Models;
using SmartPay.Server.Services.Interfaces;

namespace SmartPay.Server.Services
{
	public class PayslipService : IPayslipService
	{
		private readonly IIncomeTaxCalculator _incomeTaxCalculator;
		private readonly IGrossIncomeCalculator _grossIncomeCalculator;
		private readonly ISuperCalculator _superCalculator;
		private readonly IPayPeriodFormatter _payPeriodFormatter;

		public PayslipService(IIncomeTaxCalculator incomeTaxCalculator, IGrossIncomeCalculator grossIncomeCalculator, ISuperCalculator superCalculator , IPayPeriodFormatter payPeriodFormatter)
		{
			_incomeTaxCalculator = incomeTaxCalculator;
			_grossIncomeCalculator = grossIncomeCalculator;
			_superCalculator = superCalculator;
			_payPeriodFormatter = payPeriodFormatter;
		}

		public PayslipDetails CalculatePayslip(PayslipDetails request)
		{
			request.GrossIncome = CalculateGrossIncome(request.Employee.AnnualSalary);
			request.IncomeTax = CalculateIncomeTax(request.Employee.AnnualSalary);
			request.NetIncome = request.GrossIncome - request.IncomeTax;
			request.Super = CalculateSuper(request.GrossIncome, request.Employee.SuperRate);
			request.PayPeriod = FormatPayPeriod(request.Month, request.Year);
			return request;

			//return new PayslipDetails
			//{
			//	Employee = new Employee {
			//		FirstName = request.Employee.FirstName,
			//		LastName = request.Employee.LastName,
			//	},
			//	GrossIncome = grossIncome,
			//	IncomeTax = incomeTax,
			//	NetIncome = grossIncome - incomeTax,
			//	Super = superContribution
			//};
		}

		private decimal CalculateGrossIncome(decimal annualSalary)
		{
			return _grossIncomeCalculator.CalculateGrossIncome(annualSalary);
		}

		private decimal CalculateIncomeTax(decimal annualSalary)
		{
			return _incomeTaxCalculator.CalculateIncomeTax(annualSalary);
		}

		
		private decimal CalculateSuper(decimal grossIncome, decimal superRate)
		{
			return _superCalculator.CalculateSuper(grossIncome, superRate);
		}

		private string FormatPayPeriod(int Month, int Year)
		{
			return _payPeriodFormatter.FormatPayPeriod(Year, Month);
		}


	}
}
