using AutoMapper;
using DBank.Calculator.DTO;
using DBank.Calculator.Model;

namespace DBank.Calculator.Mappers
{
    public class LoanMapper : Profile
    {
        public LoanMapper()
        {
            CreateMap<Arguments, Loan>()
                .ForMember(dest => dest.Amount, y => y.MapFrom(src => decimal.Parse(src.Loan)))
                .ForMember(dest => dest.Duration, y => y.MapFrom(src => int.Parse(src.Years)));
        }
    }
}