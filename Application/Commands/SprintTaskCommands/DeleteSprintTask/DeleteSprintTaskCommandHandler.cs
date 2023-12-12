using Domain.Aggregates.ProjectAggregate;
using MediatR;
using Microsoft.Graph.Models;


namespace Application.Commands.SprintTaskCommands.DeleteSprintTask
{
    public class DeleteSprintTaskCommandHandler : IRequestHandler<DeleteSprintTaskCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;


        public DeleteSprintTaskCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public async Task<Unit> Handle(DeleteSprintTaskCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectChildsAsync(request.ProjectId);

            if (project != null)
            {
                var sprint = project.Sprints.FirstOrDefault(s => s.Id == request.SprintId);

                if (sprint != null)
                {
                    var sprintTask = sprint.SprintTasks.FirstOrDefault(s => s.Id == request.SprintTaskId && !s.IsDeleted);

                    if (sprintTask != null)
                    {

                        await _projectRepository.SoftDeleteSprintTaskAsync(request.ProjectId, request.SprintId, request.SprintTaskId);

                        await _projectRepository.UpdateAsync(project);
                    }
                }
            }
            return Unit.Value;
        }

    }
}
