using MediatR;


namespace Application.Commands.ProjectCommands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public int ProjectId { get; set; }
    }
}
