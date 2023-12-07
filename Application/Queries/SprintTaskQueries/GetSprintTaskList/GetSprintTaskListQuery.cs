using Application.Queries.SprintQueries.GetSprintList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.SprintTaskQueries.GetSprintTaskList
{
    

    public class GetSprintTaskListQuery : IRequest<List<GetSprintTaskListDto>>
    {
        public int Id { get; set; }
    }

}
