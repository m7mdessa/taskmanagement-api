using Domain.Aggregates.ProjectAggregate;
using MediatR;


namespace Application.Commands.SprintCommands.CreateSprint
{
    public class CreateSprintCommandHandler : IRequestHandler<CreateSprintCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;


        public CreateSprintCommandHandler(IProjectRepository projectRepository)
        {

            _projectRepository = projectRepository;
        }

        
        public async Task<Unit> Handle(CreateSprintCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetAsync(request.ProjectId);

            if(project != null)
            {
                var sprint = new Sprint(request.SprintName, request.StartDate, request.EndDate, request.ProjectId);

                project.AddSprint(sprint);

                await _projectRepository.UpdateAsync(project);
            }
             
            return Unit.Value;
        }

    }
}
