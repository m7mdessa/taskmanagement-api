using MediatR;

namespace Application.Commands.SprintCommands.DeleteSprint
{

    public class DeleteSprintCommand : IRequest<Unit>
    {
       public int ProjectId { get; set; }

        public int SprintId { get; set; }

    }
}