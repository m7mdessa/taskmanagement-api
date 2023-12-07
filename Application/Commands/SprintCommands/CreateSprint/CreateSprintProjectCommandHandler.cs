using Domain.Aggregates.ProjectAggregate;
using MediatR;


namespace Application.Commands.SprintCommands.CreateSprint
{
    public class CreateSprintProjectCommandHandler : IRequestHandler<CreateSprintProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;


        public CreateSprintProjectCommandHandler(IProjectRepository projectRepository)
        {

            _projectRepository = projectRepository;
        }

        
        public async Task<Unit> Handle(CreateSprintProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetAsync(request.ProjectId);

            if(project != null)
            {
                var sprint = new Sprint(request.SprintName, request.ProjectId);

                project.AddSprint(sprint);

                await _projectRepository.UpdateAsync(project);
            }
             
            return Unit.Value;
        }

    }
}
