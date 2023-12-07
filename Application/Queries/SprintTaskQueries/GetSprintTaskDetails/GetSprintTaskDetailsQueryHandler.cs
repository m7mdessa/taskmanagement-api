using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;
using MediatR;

namespace Application.Queries.SprintTaskQueries.GetSprintTaskDetails
{
    public class GetSprintTaskDetailsQueryHandler : IRequestHandler<GetSprintTaskDetailsQuery, GetSprintTaskDetailsDto>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;

        public GetSprintTaskDetailsQueryHandler(IProjectRepository projectRepository, IMapper mapper, IDeveloperRepository developerRepository)
        {
            _projectRepository = projectRepository;
            _developerRepository = developerRepository;
            _mapper = mapper;

        }

        public async Task<GetSprintTaskDetailsDto> Handle(GetSprintTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectChildsAsync(request.ProjectId);

            var task = project.Sprints.SelectMany(p => p.SprintTasks).FirstOrDefault(p => p.Id == request.Id);

            var data = _mapper.Map<GetSprintTaskDetailsDto>(task);

            if (task?.DeveloperId != null)
            {
                var developer = await _developerRepository.GetByIdAsync(task.DeveloperId);
                data.DeveloperName = developer?.DeveloperName ?? "Unknown";
            }

            return data;
        }
    }
}