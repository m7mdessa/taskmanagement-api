﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.SprintQueries.GetSprintList
{
    public class GetSprintListDto
    {
        public int Id { get; set; }

        public string? SprintName { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? DeveloperName { get; set; }
        public string? SprintDescription { get; set; }

        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
    }
}
