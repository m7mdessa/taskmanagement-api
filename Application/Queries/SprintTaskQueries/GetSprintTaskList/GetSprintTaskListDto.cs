

namespace Application.Queries.SprintTaskQueries.GetSprintTaskList
{
    public class GetSprintTaskListDto
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public int SprintId { get; set; }
        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }

        public string? DeveloperName { get; set; }

        public string? SprintName { get; set; }
        public string? TaskStatus { get; set; }
        public string? TaskDuration { get; set; }
    }
}
