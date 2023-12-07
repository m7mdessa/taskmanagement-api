using Application.Queries.SprintQueries.GetSprintDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.SprintQueries.GetSprintList
{
    
    public class GetSprintListQuery : IRequest<List<GetSprintListDto>>
    {
        public int Id { get; set; }
    }
}
