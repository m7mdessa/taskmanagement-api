using Domain.Aggregates.ProjectAggregate;
using MediatR;


namespace Application.Commands.ProjectCommands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;


        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {

            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.ProjectName);


            await _projectRepository.AddAsync(project);

            return Unit.Value;
        }
    }
}
