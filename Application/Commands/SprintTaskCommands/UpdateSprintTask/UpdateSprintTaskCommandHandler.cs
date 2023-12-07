
using Domain.Aggregates.ProjectAggregate;

using MediatR;

namespace Application.Commands.SprintTaskCommands.UpdateSprintTask
{
    public class UpdateSprintTaskCommandHandler : IRequestHandler<UpdateSprintTaskCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        

        public UpdateSprintTaskCommandHandler( IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(UpdateSprintTaskCommand request, CancellationToken cancellationToken)
        {
            

            var project = await _projectRepository.GetProjectChildsAsync(request.ProjectId);


            if (project != null)
            {
                project.UpdateSprintTask(request.Id, request.SprintId,request.TaskName, request.TaskDescription, request.DeveloperId, request.TaskStatus);

                await _projectRepository.UpdateAsync(project);


            }

            return Unit.Value;
        }
    }
}
