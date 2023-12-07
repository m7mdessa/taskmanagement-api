using Application.Queries.SprintTaskQueries.GetSprintTaskDetails;
using Application.Queries.SprintTaskQueries.GetSprintTaskList;
using AutoMapper;
using Domain.Aggregates.ProjectAggregate;


namespace Application.MappingProfiles
{
    public class SprintTaskProfile : Profile
    {
        public SprintTaskProfile()
        {

             CreateMap<SprintTask, GetSprintTaskListDto>()
             .ForMember(s => s.SprintName, opt => opt.MapFrom(src => src.Sprint.SprintName))
             .ForMember(dest => dest.DeveloperName, opt => opt.MapFrom<DeveloperNameResolver>());

            CreateMap<SprintTask, GetSprintTaskDetailsDto>()
            .ForMember(s => s.SprintName, opt => opt.MapFrom(src => src.Sprint.SprintName));


        }
    }
}
