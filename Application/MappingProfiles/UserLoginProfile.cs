using Application.Queries.DeveloperQueries.GetUserLoginDetails;
using Application.Queries.DeveloperQueries.GetUserLoginList;
using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;


namespace Application.MappingProfiles
{
  

    public class UserLoginProfile : Profile
    {
        public UserLoginProfile()
        {
            CreateMap<UserLogin, GetUserLoginListDto>()
           .ForMember(p => p.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<UserLogin, GetUserLoginDetailsDto>()
            .ForMember(p => p.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

        }
    }
}
