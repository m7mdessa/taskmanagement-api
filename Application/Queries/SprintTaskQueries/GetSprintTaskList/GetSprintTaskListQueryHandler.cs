using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Queries.SprintTaskQueries.GetSprintTaskList
{


    public class GetSprintTaskListQueryHandler : IRequestHandler<GetSprintTaskListQuery, List<GetSprintTaskListDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetSprintTaskListQueryHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;

        }

        public async Task<List<GetSprintTaskListDto>> Handle(GetSprintTaskListQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectChildsAsync(request.Id);

            var sprintTasks = project.Sprints.SelectMany(s => s.SprintTasks);

            var result = _mapper.Map<List<GetSprintTaskListDto>>(sprintTasks);

            return result;

        }
    }
}
