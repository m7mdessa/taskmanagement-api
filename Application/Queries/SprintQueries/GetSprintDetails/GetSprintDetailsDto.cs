using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.SprintQueries.GetSprintDetails
{
    public class GetSprintDetailsDto
    {
        public int Id { get; set; }

        public string? SprintName { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? SprintDescription { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
