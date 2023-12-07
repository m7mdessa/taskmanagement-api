using Application.Queries.SprintQueries.GetSprintDetails;
using Application.Queries.SprintQueries.GetSprintList;
using AutoMapper;
using Domain.Aggregates.ProjectAggregate;


namespace Application.MappingProfiles
{
    public class SprintProfile : Profile
    {
        public SprintProfile()
        {
            CreateMap<Sprint, GetSprintListDto>()
           .ForMember(p => p.ProjectName, opt => opt.MapFrom(src => src.Project.ProjectName));

            CreateMap<Sprint, GetSprintDetailsDto>()
            .ForMember(p => p.ProjectName, opt => opt.MapFrom(src => src.Project.ProjectName));

        }
    } 
}
