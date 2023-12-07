using Domain.Aggregates.DeveloperAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{


    public class DeveloperRepository : RepositoryBase<Developer>, IDeveloperRepository
    {

        public DeveloperRepository(TaskManagementContext context) : base(context) { }

       

    }
}

