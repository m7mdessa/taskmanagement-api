using Domain.Aggregates.DeveloperAggregate;
using MediatR;

namespace Application.Commands.DeveloperCommands.CreateDeveloper
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, Unit>
    {

        private readonly IDeveloperRepository _developerRepository;


        public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository)
        {

            _developerRepository = developerRepository;
        }



        public async Task<Unit> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Street, request.City, request.State, request.Country, request.ZipCode);

            var developer = new Developer(request.Id, request.FirstName, request.LastName, request.Email, address, request.UserName, request.Password);
            await _developerRepository.AddAsync(developer);

            return Unit.Value;
        }
    }
}
