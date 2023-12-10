using Domain.Aggregates.ProjectAggregate;
using Domain.SharedKernel;
using MediatR;


namespace Application.Commands.ProjectCommands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IGenericRepository<Project> _projectRepository;

        public DeleteProjectCommandHandler(IGenericRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetAsync(request.Id);

            await _projectRepository.DeleteAsync(project);

            return Unit.Value;
        }
    }
}
