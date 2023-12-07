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
            CreateMap<Developer, GetDeveloperListDto>();

            CreateMap<Developer, GetDeveloperDetailsDto>();

        }
    }
}
