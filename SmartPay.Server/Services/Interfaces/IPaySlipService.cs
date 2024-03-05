using System;
using SmartPay.Server.Dto;
using SmartPay.Server.Models;

	namespace SmartPay.Server.Services.Interfaces
{
	public interface IPayslipService
	{
		public PayslipDetails CalculatePayslip(PayslipDetails request);

	}
}
