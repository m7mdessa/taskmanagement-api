using MediatR;

namespace Application.Commands.SprintCommands.UpdateSprint
{
    public class UpdateSprintCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? SprintName { get;  set; }
        public int ProjectId { get;  set; }
        public string? SprintDescription { get; set; }

    }
}
