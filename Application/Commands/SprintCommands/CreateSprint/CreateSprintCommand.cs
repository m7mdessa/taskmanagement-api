using MediatR;


namespace Application.Commands.SprintCommands.CreateSprint
{
    public class CreateSprintCommand : IRequest<Unit>
    {
        public string? SprintName { get;  set; }
        public int ProjectId { get;  set; }
        public string? SprintDescription { get;  set; }

        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
    }
}
