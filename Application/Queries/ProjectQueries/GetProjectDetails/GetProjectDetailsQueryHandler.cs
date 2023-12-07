using AutoMapper;
using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using MediatR;


namespace Application.Queries.ProjectQueries.GetProjectDetails
{
    public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, GetProjectDetailsDto>
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<Project> _projectRepository;

        public GetProjectDetailsQueryHandler(IGenericRepository<Project> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<GetProjectDetailsDto> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _projectRepository.GetByIdAsync(request.Id);

                        var data = _mapper.Map<GetProjectDetailsDto>(leaveType);

            return data;
        }
    }
}
