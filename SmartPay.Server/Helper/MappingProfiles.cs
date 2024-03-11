using AutoMapper;
using SmartPay.Server.Dto;
using SmartPay.Server.Models;

namespace SmartPay.Server.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<PayslipRequestDto, PayslipDetails>()
			.ForMember(dest => dest.Employee, opt => opt.MapFrom(src => new Employee(src.FirstName, src.LastName, src.AnnualSalary, src.SuperRate)));

			CreateMap<PayslipDetails, PayslipDetailsDto>();


		}
	}
}
