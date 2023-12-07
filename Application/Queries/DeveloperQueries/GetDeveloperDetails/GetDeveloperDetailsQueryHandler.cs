using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;
using Domain.SharedKernel;
using MediatR;

namespace Application.Queries.DeveloperQueries.GetDeveloperDetails
{
    public class GetDeveloperDetailsQueryHandler : IRequestHandler<GetDeveloperDetailsQuery, GetDeveloperDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Developer> _developerRepository;
        public GetDeveloperDetailsQueryHandler(IGenericRepository<Developer> developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }

        public async Task<GetDeveloperDetailsDto> Handle(GetDeveloperDetailsQuery request, CancellationToken cancellationToken)
        {


            var developer = await _developerRepository.GetByIdAsync(request.Id);


            var data = _mapper.Map<GetDeveloperDetailsDto>(developer);

            return data;
        }
    }
}