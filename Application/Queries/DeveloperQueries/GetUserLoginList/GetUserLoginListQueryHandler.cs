using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;
using Domain.SharedKernel;
using MediatR;


namespace Application.Queries.DeveloperQueries.GetUserLoginList
{

    public class GetUserLoginListQueryHandler : IRequestHandler<GetUserLoginListQuery, List<GetUserLoginListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDeveloperRepository _developerRepository;

        public GetUserLoginListQueryHandler(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;

        }

        public async Task<List<GetUserLoginListDto>> Handle(GetUserLoginListQuery request, CancellationToken cancellationToken)
        {


            var developer = await _developerRepository.GetDeveloperChildsAsync(request.Id);

            var userLogins = developer.UserLogins;


            var data = _mapper.Map<List<GetUserLoginListDto>>(userLogins);

            return data;
        }
    }
}
