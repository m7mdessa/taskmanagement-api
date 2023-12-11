using Application.Queries.SprintQueries.GetSprintDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.DeveloperQueries.GetUserLoginDetails
{
   

    public class GetUserLoginDetailsQuery : IRequest<GetUserLoginDetailsDto>
    {
        public int DeveloperId { get; set; }
        public int Id { get; set; }


    }
}
