

namespace Application.Queries.SprintTaskQueries.GetSprintTaskDetails
{
    public class GetSprintTaskDetailsDto
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public int SprintId { get; set; }
        public int DeveloperId { get;  set; }
        public string? DeveloperName { get; set; }

        public string? SprintName { get; set; }
        public string? TaskStatus { get;  set; }
        public DateTime TaskDuration { get;  set; }


    }
}
