using Application.Queries.DeveloperQueries.GetDeveloperDetails;
using Application.Queries.SprintQueries.GetSprintDetails;
using AutoMapper;
using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.DeveloperQueries.GetUserLoginDetails
{


    public class GetUserLoginDetailsQueryHandler : IRequestHandler<GetUserLoginDetailsQuery, GetUserLoginDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IDeveloperRepository _developerRepository;
        public GetUserLoginDetailsQueryHandler(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }

        public async Task<GetUserLoginDetailsDto> Handle(GetUserLoginDetailsQuery request, CancellationToken cancellationToken)
        {

           
            var developer = await _developerRepository.GetDeveloperChildsAsync(request.DeveloperId);

            var userLogin = developer.UserLogins.FirstOrDefault(s => s.DeveloperId == request.DeveloperId);


            var data = _mapper.Map<GetUserLoginDetailsDto>(userLogin);

            return data;
        }
    }
}
