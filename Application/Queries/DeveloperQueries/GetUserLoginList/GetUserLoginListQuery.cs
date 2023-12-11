using Application.Queries.DeveloperQueries.GetUserLoginDetails;
using Application.Queries.SprintQueries.GetSprintList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.DeveloperQueries.GetUserLoginList
{
  

    public class GetUserLoginListQuery : IRequest<List<GetUserLoginListDto>>
    {
        public int Id { get; set; }
    }
}
