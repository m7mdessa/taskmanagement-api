using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;
using MediatR;


namespace Application.Queries.SprintTaskQueries.GetDeveloperSprintTaskList
{


    public class GetDeveloperSprintTaskListHandler : IRequestHandler<GetDeveloperSprintTaskListQuery, List<GetDeveloperSprintTaskListDto>>
    {
        private readonly IProjectRepository _projectRepository; 

        private readonly IMapper _mapper;

        public GetDeveloperSprintTaskListHandler( IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<GetDeveloperSprintTaskListDto>> Handle(GetDeveloperSprintTaskListQuery request, CancellationToken cancellationToken)
        {

            var project = await _projectRepository.GetDeveloperTasksAsync(request.ProjectId, request.DeveloperId);

            var sprintTask = project.Sprints.SelectMany(s => s.SprintTasks).Where(st => st.DeveloperId == request.DeveloperId);


            var result = _mapper.Map<List<GetDeveloperSprintTaskListDto>>(sprintTask);

            return result;
        }




    }

}
