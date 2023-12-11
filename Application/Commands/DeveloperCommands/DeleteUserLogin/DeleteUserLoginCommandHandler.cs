using Application.Commands.SprintCommands.DeleteSprint;
using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeveloperCommands.DeleteUserLogin
{


    public class DeleteUserLoginCommandHandler : IRequestHandler<DeleteUserLoginCommand, Unit>
    {
        private readonly IDeveloperRepository _developerRepository;


        public DeleteUserLoginCommandHandler(IDeveloperRepository developerRepository)
        {

            _developerRepository = developerRepository;
        }



        public async Task<Unit> Handle(DeleteUserLoginCommand request, CancellationToken cancellationToken)
        {
            var developer = await _developerRepository.GetByIdAsync(request.DeveloperId, u => u.UserLogins);

            if (developer != null)
            {
                    developer.RemoveUserLogin(request.DeveloperId);

                    await _developerRepository.UpdateAsync(developer);
            
            }

            return Unit.Value;



        }


    }
}
