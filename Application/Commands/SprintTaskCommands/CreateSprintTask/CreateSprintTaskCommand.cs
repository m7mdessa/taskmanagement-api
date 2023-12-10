using MediatR;


namespace Application.Commands.SprintTaskCommands.CreateSprintTask
{
    public class CreateSprintTaskCommand : IRequest<Unit>
    {
        public string? TaskName { get;  set; }
        public string? TaskDescription { get;  set; }
        public int SprintId { get;  set; }
        public int ProjectId { get; set; }

        public int DeveloperId { get; set; }
        public string? TaskDuration { get;  set; }


    }

}
