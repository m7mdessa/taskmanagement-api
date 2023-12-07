using Application.Queries.SprintTaskQueries.GetSprintTaskList;
using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;

public class DeveloperNameResolver : IValueResolver<SprintTask, GetSprintTaskListDto, string>
{
    private readonly IDeveloperRepository _developerRepository;

    public DeveloperNameResolver(IDeveloperRepository developerRepository)
    {
        _developerRepository = developerRepository;
    }

    public string Resolve(SprintTask source, GetSprintTaskListDto destination, string destMember, ResolutionContext context)
    {
        var developer = _developerRepository.GetAsync(source.DeveloperId).Result;

        return developer?.DeveloperName ?? "Unknown";
    }

}
