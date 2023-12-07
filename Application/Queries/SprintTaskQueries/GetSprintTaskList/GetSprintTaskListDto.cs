using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.SprintTaskQueries.GetSprintTaskList
{
    public class GetSprintTaskListDto
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public int SprintId { get; set; }
        public int DeveloperId { get; set; }
        public string? DeveloperName { get; set; }

        public string? SprintName { get; set; }
        public string? TaskStatus { get; set; }
        public DateTime TaskDuration { get; set; }
    }
}
