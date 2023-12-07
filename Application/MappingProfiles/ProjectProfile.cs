using Application.Queries.ProjectQueries.GetProjectDetails;
using Application.Queries.ProjectQueries.GetProjectList;
using AutoMapper;
using Domain.Aggregates.ProjectAggregate;


namespace Application.MappingProfiles
{
   
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, GetProjectListDto>();
            CreateMap<Project, GetProjectDetailsDto>();

        }
    }
}
