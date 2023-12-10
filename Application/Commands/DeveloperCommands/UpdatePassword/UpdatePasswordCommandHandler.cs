using Domain.Aggregates.DeveloperAggregate;
using MediatR;

namespace Application.Commands.DeveloperCommands.UpdatePassword
{
    

    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, Unit>
    {
        private readonly IDeveloperRepository _developerRepository;


        public UpdatePasswordCommandHandler(IDeveloperRepository developerRepository)
        {

            _developerRepository = developerRepository;
        }

        public async Task<Unit> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {

            var developer = await _developerRepository.GetByIdAsync(request.DeveloperId ,u=>u.UserLogins);

            developer.UpdatePassword(request.DeveloperId, request.Password);

            await _developerRepository.UpdateAsync(developer);
            return Unit.Value;
        }


    }
}
