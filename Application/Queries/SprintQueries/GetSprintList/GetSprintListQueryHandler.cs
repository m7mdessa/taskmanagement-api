using AutoMapper;
using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using MediatR;


namespace Application.Queries.SprintQueries.GetSprintList
{
   

    public class GetSprintListQueryHandler : IRequestHandler<GetSprintListQuery, List<GetSprintListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Project> _projectRepository;

        public GetSprintListQueryHandler(IGenericRepository<Project> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;

        }

        public async Task<List<GetSprintListDto>> Handle(GetSprintListQuery request, CancellationToken cancellationToken)
        {


            var project = await _projectRepository.GetByIdAsync(request.Id,u => u.Sprints);
            var sprints = project.Sprints;

            var data = _mapper.Map<List<GetSprintListDto>>(sprints);

            return data;
        }
    }
}
