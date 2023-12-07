using MediatR;

namespace Application.Commands.SprintTaskCommands.UpdateSprintTask
{
    public class UpdateSprintTaskCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public string? TaskStatus { get; set; }
        public int SprintId { get; set; }
        public int ProjectId { get; set; }

        public int DeveloperId { get; set; }
    }
}
