using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using MediatR;


namespace Application.Commands.SprintTaskCommands.CreateSprintTask
{
    public class CreateSprintTaskCommandHandler : IRequestHandler<CreateSprintTaskCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateSprintTaskCommandHandler( IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
           
        }
        public async Task<Unit> Handle(CreateSprintTaskCommand request, CancellationToken cancellationToken)
        {
          

            var project = await _projectRepository.GetByIdAsync(request.ProjectId, s => s.Sprints);

            if (project != null)
            {
                var sprintTask = new SprintTask(request.TaskName, request.TaskDescription, request.SprintId, request.DeveloperId, request.TaskDuration);


                project.AddSprintTaskToSprint(request.SprintId, sprintTask);

                await _projectRepository.UpdateAsync(project);

            }

            return Unit.Value;
        }
    }
}
