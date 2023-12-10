using Domain.Aggregates.DeveloperAggregate;
using MediatR;

namespace Application.Commands.DeveloperCommands.DeleteDeveloper
{
    public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, Unit>
    {

        private readonly IDeveloperRepository _developerRepository;


        public DeleteDeveloperCommandHandler(IDeveloperRepository developerRepository)
        {

            _developerRepository = developerRepository;
        }


        public async Task<Unit> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = await _developerRepository.GetAsync(request.Id);

            await _developerRepository.DeleteAsync(developer);


            return Unit.Value;
        }
    }
}
