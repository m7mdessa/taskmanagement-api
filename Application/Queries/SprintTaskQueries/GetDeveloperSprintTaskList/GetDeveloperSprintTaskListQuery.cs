using Application.Queries.SprintTaskQueries.GetSprintTaskList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.SprintTaskQueries.GetDeveloperSprintTaskList
{


    public class GetDeveloperSprintTaskListQuery : IRequest<List<GetDeveloperSprintTaskListDto>>
    {
        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }

    }
}
