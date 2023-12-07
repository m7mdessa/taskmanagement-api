using MediatR;


namespace Application.Commands.ProjectCommands.CreateProject
{
    public class CreateProjectCommand : IRequest<Unit>
    {
        public string? ProjectName { get; set; }

    }
}
