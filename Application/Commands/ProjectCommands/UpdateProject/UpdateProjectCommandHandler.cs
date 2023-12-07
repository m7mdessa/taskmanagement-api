using Domain.Aggregates.ProjectAggregate;
using MediatR;

namespace Application.Commands.ProjectCommands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {

            var project = await _projectRepository.GetByIdAsync(Convert.ToInt32(request.Id));

            project.UpdateProject(request.Id, request.ProjectName);

            await _projectRepository.UpdateAsync(project);
            return Unit.Value;
        }
    }
}
