using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.SprintQueries.GetSprintDetails
{
   
    public class GetSprintDetailsQuery : IRequest<GetSprintDetailsDto>
    {
        public int ProjectId { get; set; }
        public int Id { get; set; }


    }
}
