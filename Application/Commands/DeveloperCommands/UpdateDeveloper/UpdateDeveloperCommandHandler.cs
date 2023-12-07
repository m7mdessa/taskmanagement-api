using Domain.Aggregates.DeveloperAggregate;
using MediatR;


namespace Application.Commands.DeveloperCommands.UpdateDeveloper
{
    public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, Unit>
    {
        private readonly IDeveloperRepository _developerRepository;


        public UpdateDeveloperCommandHandler(IDeveloperRepository developerRepository)
        {

            _developerRepository = developerRepository;
        }

        public async Task<Unit> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {

            var developer = await _developerRepository.GetByIdAsync(request.Id);

            var address = new Address(request.Street, request.City, request.State, request.Country, request.ZipCode);

            developer.UpdateDeveloper(request.Id, request.Firstname, request.Lastname, address);

            await _developerRepository.UpdateAsync(developer);
            return Unit.Value;
        }
    }
}
