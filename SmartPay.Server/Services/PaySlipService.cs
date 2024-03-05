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

		public PayslipService(IIncomeTaxCalculator incomeTaxCalculator, IGrossIncomeCalculator grossIncomeCalculator, ISuperCalculator superCalculator)
		{
			_incomeTaxCalculator = incomeTaxCalculator;
			_grossIncomeCalculator = grossIncomeCalculator;
			_superCalculator = superCalculator;
		}

		public PayslipDetails CalculatePayslip(PayslipDetails request)
		{
			var payPeriodStart = new DateTime(request.Year, request.Month, 1);
			var payPeriodEnd = payPeriodStart.AddMonths(1).AddDays(-1);

			var grossIncome = CalculateGrossIncome(request.Employee.AnnualSalary);
			var incomeTax = CalculateIncomeTax(request.Employee.AnnualSalary);
			var superContribution = CalculateSuper(grossIncome, request.Employee.SuperRate);

			return new PayslipDetails
			{
				Employee = new Employee {
					FirstName = request.Employee.FirstName,
					LastName = request.Employee.LastName,
				},
				GrossIncome = grossIncome,
				IncomeTax = incomeTax,
				NetIncome = grossIncome - incomeTax,
				Super = superContribution
			};
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


	}
}
