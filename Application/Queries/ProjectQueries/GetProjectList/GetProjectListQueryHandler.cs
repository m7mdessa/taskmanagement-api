using AutoMapper;
using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Queries.ProjectQueries.GetProjectList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, List<GetProjectListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Project> _projectRepository;

        public GetProjectListQueryHandler(IGenericRepository<Project> projectRepository, IMapper mapper)
        {
           _projectRepository = projectRepository;
           _mapper = mapper;
        }
        public async Task<List<GetProjectListDto>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            
                var projects = await _projectRepository.GetAllAsync(d => d.Sprints);

                var data = _mapper.Map<List<GetProjectListDto>>(projects);

                return data;
            
          


        }
    }
}
