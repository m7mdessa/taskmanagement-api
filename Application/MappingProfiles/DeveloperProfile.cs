using Application.Queries.DeveloperQueries.GetDeveloperDetails;
using Application.Queries.DeveloperQueries.GetDeveloperList;
using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;

namespace Application.MappingProfiles
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            CreateMap<Developer, GetDeveloperListDto>()
           .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
           .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
           .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
           .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
           .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country));


            CreateMap<Developer, GetDeveloperDetailsDto>()
           .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
           .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
           .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
           .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
           .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country));

        }
    }
}
