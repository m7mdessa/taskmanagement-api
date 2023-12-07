using Application.Queries.SprintQueries.GetSprintList;
using AutoMapper;
using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using MediatR;


namespace Application.Queries.SprintQueries.GetSprintDetails
{
   



    public class GetSprintDetailsQueryHandler : IRequestHandler<GetSprintDetailsQuery, GetSprintDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Project> _projectRepository;

        public GetSprintDetailsQueryHandler(IGenericRepository<Project> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;

        }

        public async Task<GetSprintDetailsDto> Handle(GetSprintDetailsQuery request, CancellationToken cancellationToken)
        {

            var project = await _projectRepository.GetByIdAsync(request.ProjectId, u => u.Sprints);
            var sprint = project.Sprints.FirstOrDefault(s => s.Id == request.Id);

            var data = _mapper.Map<GetSprintDetailsDto>(sprint);

            return data;
        }
    }
}
