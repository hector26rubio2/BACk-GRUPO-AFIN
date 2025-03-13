namespace Aplication.AutoMapperProfiles
{
    using Aplication.DTOs;
    using AutoMapper;
    using Domain.Models;

    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Common))
            .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
            .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
            .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages))
            .ForMember(dest => dest.Flag, opt => opt.MapFrom(src => src.Flags.Png));
        }
    }
}
