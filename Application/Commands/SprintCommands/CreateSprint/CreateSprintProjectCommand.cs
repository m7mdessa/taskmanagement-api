using MediatR;


namespace Application.Commands.SprintCommands.CreateSprint
{
    public class CreateSprintProjectCommand : IRequest<Unit>
    {
        public string? SprintName { get;  set; }
        public int ProjectId { get;  set; }
    }
}
