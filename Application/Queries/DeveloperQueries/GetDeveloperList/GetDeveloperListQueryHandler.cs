using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;
using Domain.SharedKernel;
using MediatR;



namespace Application.Queries.DeveloperQueries.GetDeveloperList
{
    public class GetDeveloperListQueryHandler : IRequestHandler<GetDeveloperListQuery, List<GetDeveloperListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Developer> _developerRepository;
        public GetDeveloperListQueryHandler(IGenericRepository<Developer> developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }


        public async Task<List<GetDeveloperListDto>> Handle(GetDeveloperListQuery request, CancellationToken cancellationToken)
        {

            var developers = await _developerRepository.GetAllAsync();

            var data = _mapper.Map<List<GetDeveloperListDto>>(developers);

            return data;



        }
    }
}
