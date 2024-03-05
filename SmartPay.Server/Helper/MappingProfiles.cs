using AutoMapper;
using SmartPay.Server.Dto;
using SmartPay.Server.Models;

namespace SmartPay.Server.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<PayslipRequestDto, PayslipDetailsDto>()
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
			.ForMember(dest => dest.PayPeriod, opt => opt.Ignore());

		}
	}
}
