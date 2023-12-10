using Domain.Aggregates.ProjectAggregate;
using MediatR;


namespace Application.Commands.SprintCommands.UpdateSprint
{
    public class UpdateSprintCommandHandler : IRequestHandler<UpdateSprintCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;


        public UpdateSprintCommandHandler(IProjectRepository projectRepository)
        {

            _projectRepository = projectRepository;
        }


        public async Task<Unit> Handle(UpdateSprintCommand request, CancellationToken cancellationToken)
        {

            var project = await _projectRepository.GetByIdAsync(request.ProjectId, s => s.Sprints);

            if (project != null)
            {
                project.UpdateSprint(request.Id, request.ProjectId,request.SprintName,request.SprintDescription);

                    await _projectRepository.UpdateAsync(project);
                
            }

            return Unit.Value;
        }
    }
}
