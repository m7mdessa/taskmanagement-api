using MediatR;

namespace Application.Commands.SprintTaskCommands.DeleteSprintTask
{

    public class DeleteSprintTaskCommand : IRequest<Unit>
    {
        public int ProjectId { get; set; }
        public int SprintId { get; set; }
        public int SprintTaskId { get; set; }

        
    }
}